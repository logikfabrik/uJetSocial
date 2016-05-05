(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetUmbracoMediaFactory", ujetUmbracoMediaFactory);

    ujetUmbracoMediaFactory.$inject = ["$http"];

    function ujetUmbracoMediaFactory($http) {
        var factory = {
            query: query
        };

        return factory;

        function query(q) {
            return $http.post("backoffice/uJetSocial/UmbracoMediaAPI/Query", q);
        }
    };
})();