(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetUmbracoDocumentFactory", ujetUmbracoDocumentFactory);

    ujetUmbracoDocumentFactory.$inject = ["$http"];

    function ujetUmbracoDocumentFactory($http) {
        var factory = {
            query: query
        };

        return factory;

        function query(q) {
            return $http.post("backoffice/uJetSocial/UmbracoDocumentAPI/Query", q);
        }
    };
})();