(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetUmbracoDocumentFactory", ujetUmbracoDocumentFactory);

    ujetUmbracoDocumentFactory.$inject = ["$http"];

    function ujetUmbracoDocumentFactory($http) {
        var factory = {
            get: get,
            query: query
        };

        return factory;

        function get(id) {
            return $http.get("backoffice/uJetSocial/UmbracoDocumentAPI/Get/" + id);
        }

        function query(q) {
            return $http.post("backoffice/uJetSocial/UmbracoDocumentAPI/Query", q);
        }
    };
})();