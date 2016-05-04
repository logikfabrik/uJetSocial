(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetEntityFactory", ujetEntityFactory);

    ujetEntityFactory.$inject = [
        "$http",
        "$filter",
        "$q",
        "ujetCommentFactory",
        "ujetGroupFactory",
        "ujetGuestFactory",
        "ujetReportFactory"
    ];

    function ujetEntityFactory($http, $filter, $q, ujetCommentFactory, ujetGroupFactory, ujetGuestFactory, ujetReportFactory) {
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
            return $http.get("backoffice/uJetSocial/EntityAPI/GetType/" + id);
        }

        function getFactory(type) {
            switch (type.name) {
                case "Comment":
                    return ujetCommentFactory;
                case "Group":
                    return ujetGroupFactory;
                case "IndividualGuest":
                    return ujetGuestFactory;
                case "Report":
                    return ujetReportFactory;
                default:
                    return null;
            }
        }

        function getFilter(type) {
            switch (type.name) {
                case "Comment":
                    return $filter("ujetAsComment");
                case "Group":
                    return $filter("ujetAsGroup");
                case "IndividualGuest":
                    return $filter("ujetAsGuest");
                case "Report":
                    return $filter("ujetAsReport");
                default:
                    return null;
            }
        }
    };
})();