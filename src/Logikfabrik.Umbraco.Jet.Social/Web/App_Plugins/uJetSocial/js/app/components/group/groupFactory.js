angular.module("umbraco.resources")
    .factory("groupFactory", [
        "$http", function ($http) {
            var dataFactory = {};

            dataFactory.search = function (searchQuery) {
                return $http.post("backoffice/uJetSocial/GroupAPI/Search", searchQuery);
            };

            return dataFactory;
        }
    ]);