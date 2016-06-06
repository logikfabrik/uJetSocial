(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetDocumentFactory", ujetDocumentFactory);

    ujetDocumentFactory.$inject = ["$http"];

    function ujetDocumentFactory($http) {
        var factory = {
            get: get,
            getByDocumentId: getByDocumentId,
            query: query
        };

        return factory;

        function get(id) {
            return $http.get("backoffice/uJetSocial/DocumentAPI/Get/" + id);
        }

        function getByDocumentId(id) {
            return $http.get("backoffice/uJetSocial/DocumentAPI/GetByDocumentId/" + id);
        }

        function query(q) {
            return $http.post("backoffice/uJetSocial/DocumentAPI/Query", q);
        }
    };
})();