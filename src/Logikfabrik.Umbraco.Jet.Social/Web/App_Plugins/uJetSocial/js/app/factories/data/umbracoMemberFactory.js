(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetUmbracoMemberFactory", ujetUmbracoMemberFactory);

    ujetUmbracoMemberFactory.$inject = ["$http"];

    function ujetUmbracoMemberFactory($http) {
        var factory = {
            get: get,
            query: query
        };

        return factory;

        function get(id) {
            return $http.get("backoffice/uJetSocial/UmbracoMemberAPI/Get/" + id);
        }

        function query(q) {
            return $http.post("backoffice/uJetSocial/UmbracoMemberAPI/Query", q);
        }
    };
})();