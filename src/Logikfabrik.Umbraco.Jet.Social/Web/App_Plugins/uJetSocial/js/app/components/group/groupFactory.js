(function () {
    'use strict';

    angular
        .module("umbraco.resources")
        .factory("ujetGroupFactory", ujetGroupFactory);

    ujetGroupFactory.$inject = ["$http"];

    function ujetGroupFactory($http) {
        var factory = {
            add: add,
            update: update,
            get: get,
            query: query
        };

        return factory;

        function add(dto) {
            return $http.post("backoffice/uJetSocial/GroupAPI/Add", dto);
        }

        function update(dto) {
            return $http({
                method: "POST",
                url: "backoffice/uJetSocial/GroupAPI/Update",
                params: {
                    id: dto.Id
                },
                data: dto
            });
        }

        function get(id) {
            return $http.get("backoffice/uJetSocial/GroupAPI/Get/" + id);
        }

        function query(q) {
            return $http.post("backoffice/uJetSocial/GroupAPI/Query", q);
        }
    };
})();