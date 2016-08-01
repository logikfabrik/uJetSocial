(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetGroupMembershipFactory", ujetGroupMembershipFactory);

    ujetGroupMembershipFactory.$inject = ["$http"];

    function ujetGroupMembershipFactory($http) {
        var factory = {
            add: add,
            get: get,
            query: query,
            remove: remove
        };

        return factory;

        function add(dto) {
            return $http.post("backoffice/uJetSocial/GroupMembershipAPI/Add", dto);
        }

        function get(id) {
            return $http.get("backoffice/uJetSocial/GroupMembershipAPI/Get/" + id);
        }

        function query(q) {
            return $http.post("backoffice/uJetSocial/GroupMembershipAPI/Query", q);
        }

        function remove(id) {
            return $http.post("backoffice/uJetSocial/GroupMembershipAPI/Remove", id);
        }
    };
})();