(function () {
    'use strict';

    angular
        .module("umbraco.resources")
        .factory("ujetGuestFactory", ujetGuestFactory);

    ujetGuestFactory.$inject = ["$http"];

    function ujetGuestFactory($http) {
        var factory = {
            add: add,
            update: update,
            get: get,
            query: query
        };

        return factory;

        function add(dto) {
            return $http.post("backoffice/uJetSocial/IndividualGuestAPI/Add", dto);
        }

        function update(dto) {
            return $http({
                method: "POST",
                url: "backoffice/uJetSocial/IndividualGuestAPI/Update",
                params: {
                    id: dto.Id
                },
                data: dto
            });
        }

        function get(id) {
            return $http.get("backoffice/uJetSocial/IndividualGuestAPI/Get/" + id);
        }

        function query(q) {
            return $http.post("backoffice/uJetSocial/IndividualGuestAPI/Query", q);
        }
    };
})();