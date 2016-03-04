(function () {
    "use strict";

    angular
        .module("umbraco.resources")
        .factory("ujetReportFactory", ujetReportFactory);

    ujetReportFactory.$inject = ["$http"];

    function ujetReportFactory($http) {
        var factory = {
            add: add,
            update: update,
            get: get,
            query: query
        };

        return factory;

        function add(dto) {
            return $http.post("backoffice/uJetSocial/ReportAPI/Add", dto);
        }

        function update(dto) {
            return $http({
                method: "POST",
                url: "backoffice/uJetSocial/ReportAPI/Update",
                params: {
                    id: dto.id
                },
                data: dto
            });
        }

        function get(id) {
            return $http.get("backoffice/uJetSocial/ReportAPI/Get/" + id);
        }

        function query(q) {
            return $http.post("backoffice/uJetSocial/ReportAPI/Query", q);
        }
    };
})();