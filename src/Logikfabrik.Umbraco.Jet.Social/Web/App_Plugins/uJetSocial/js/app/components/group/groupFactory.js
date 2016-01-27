angular.module("umbraco.resources")
    .factory("groupFactory", [
        "$http", function ($http) {
            var dataFactory = {};

            dataFactory.add = function (dto) {
                return $http.post("backoffice/uJetSocial/GroupAPI/Add", dto);
            };

            dataFactory.update = function (dto) {
                return $http({
                    method: "POST",
                    url: "backoffice/uJetSocial/GroupAPI/Update",
                    params: {
                        id: dto.Id
                    },
                    data: dto
                });
            };

            dataFactory.get = function (id) {
                return $http.get("backoffice/uJetSocial/GroupAPI/Get/" + id);
            };

            dataFactory.query = function (query) {
                return $http.post("backoffice/uJetSocial/GroupAPI/Query", query);
            };

            return dataFactory;
        }
    ]);