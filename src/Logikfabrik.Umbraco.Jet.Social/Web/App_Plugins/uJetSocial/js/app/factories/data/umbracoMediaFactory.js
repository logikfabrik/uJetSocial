(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetUmbracoMediaFactory", ujetUmbracoMediaFactory);

    ujetUmbracoMediaFactory.$inject = ["$http"];

    function ujetUmbracoMediaFactory($http) {
        var factory = {
            get: get,
            query: query
        };

        return factory;

        function get(id) {
            return $http.get("backoffice/uJetSocial/UmbracoMediaAPI/Get/" + id);
        }

        function query(q) {
            return $http.post("backoffice/uJetSocial/UmbracoMediaAPI/Query", q);
        }
    };
})();