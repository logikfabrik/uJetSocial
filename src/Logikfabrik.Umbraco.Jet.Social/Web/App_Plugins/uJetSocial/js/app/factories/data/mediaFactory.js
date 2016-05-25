﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetMediaFactory", ujetMediaFactory);

    ujetMediaFactory.$inject = ["$http"];

    function ujetMediaFactory($http) {
        var factory = {
            get: get,
            getByMediaId: getByMediaId
        };

        return factory;

        function get(id) {
            return $http.get("backoffice/uJetSocial/MediaAPI/Get/" + id);
        }

        function getByMediaId(id) {
            return $http.get("backoffice/uJetSocial/MediaAPI/GetByMediaId/" + id);
        }
    };
})();