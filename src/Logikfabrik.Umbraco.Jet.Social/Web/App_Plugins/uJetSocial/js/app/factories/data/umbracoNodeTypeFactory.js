(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetUmbracoNodeTypeFactory", ujetUmbracoNodeTypeFactory);

    ujetUmbracoNodeTypeFactory.$inject = [
        "$http",
        "$filter",
        "$q",
        "ujetUmbracoDocumentFactory",
        "ujetUmbracoMemberFactory",
        "ujetUmbracoMediaFactory"
    ];

    function ujetUmbracoNodeTypeFactory(
        $http,
        $filter,
        $q,
        ujetUmbracoDocumentFactory,
        ujetUmbracoMemberFactory,
        ujetUmbracoMediaFactory) {
        var factory = {
            get: get
        };

        return factory;

        function get(id) {
            var defer = $q.defer();
            var type;

            getType(id)
                .then(function (response) {
                    type = response.data;

                    return getFactory(type).get(id);
                })
                .then(function (response) {
                    var filter = getFilter(type);

                    defer.resolve(filter(response.data));
                });

            return defer.promise;
        }

        function getType(id) {
            return $http.get("backoffice/uJetSocial/UmbracoNodeTypeAPI/GetType/" + id);
        }

        function getFactory(type) {
            switch (type.name) {
                case "UmbracoDocument":
                    return ujetUmbracoDocumentFactory;
                case "UmbracoMember":
                    return ujetUmbracoMemberFactory;
                case "UmbracoMedia":
                    return ujetUmbracoMediaFactory;
                default:
                    return null;
            }
        }

        function getFilter(type) {
            switch (type.name) {
                case "UmbracoDocument":
                    return $filter("ujetAsUmbracoDocument");
                case "UmbracoMember":
                    return $filter("ujetAsUmbracoMember");
                case "UmbracoMedia":
                    return $filter("ujetAsUmbracoMedia");
                default:
                    return null;
            }
        }
    };
})();