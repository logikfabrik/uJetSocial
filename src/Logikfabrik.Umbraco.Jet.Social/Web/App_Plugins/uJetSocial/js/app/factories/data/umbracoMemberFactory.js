(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetUmbracoMemberFactory", ujetUmbracoMemberFactory);

    ujetUmbracoMemberFactory.$inject = ["$http"];

    function ujetUmbracoMemberFactory($http) {
        var factory = {
            query: query
        };

        return factory;

        function query(q) {
            return $http.post("backoffice/uJetSocial/UmbracoMemberAPI/Query", q);
        }
    };
})();