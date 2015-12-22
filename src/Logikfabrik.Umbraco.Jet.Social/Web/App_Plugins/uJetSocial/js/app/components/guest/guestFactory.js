angular.module("umbraco.resources")
    .factory("guestFactory", [
        "$http", function ($http) {
            var dataFactory = {};

            dataFactory.add = function(dto) {
                return $http.post("backoffice/uJetSocial/IndividualGuestAPI/Add", dto);
            }

            dataFactory.query = function (query) {
                return $http.post("backoffice/uJetSocial/IndividualGuestAPI/Query", query);
            };

            return dataFactory;
        }
    ]);