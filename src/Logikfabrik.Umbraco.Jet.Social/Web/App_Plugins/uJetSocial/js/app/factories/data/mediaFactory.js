﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetMediaFactory", ujetMediaFactory);

    ujetMediaFactory.$inject = ["$http"];

    function ujetMediaFactory($http) {
        var factory = {
            update: update,
            get: get,
            getByMediaId: getByMediaId,
            query: query
        };

        return factory;

        function update(dto) {
            return $http({
                method: "POST",
                url: "backoffice/uJetSocial/MediaAPI/Update",
                params: {
                    id: dto.id
                },
                data: dto
            });
        }

        function get(id) {
            return $http.get("backoffice/uJetSocial/MediaAPI/Get/" + id);
        }

        function getByMediaId(id) {
            return $http.get("backoffice/uJetSocial/MediaAPI/GetByMediaId/" + id);
        }

        function query(q) {
            return $http.post("backoffice/uJetSocial/MediaAPI/Query", q);
        }
    };
})();