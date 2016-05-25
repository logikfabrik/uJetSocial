(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetIndividualMemberFactory", ujetIndividualMemberFactory);

    ujetIndividualMemberFactory.$inject = ["$http"];

    function ujetIndividualMemberFactory($http) {
        var factory = {
            get: get,
            getByMemberId: getByMemberId
        };

        return factory;

        function get(id) {
            return $http.get("backoffice/uJetSocial/IndividualMemberAPI/Get/" + id);
        }

        function getByMemberId(id) {
            return $http.get("backoffice/uJetSocial/IndividualMemberAPI/GetByMemberId/" + id);
        }
    };
})();