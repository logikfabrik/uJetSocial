angular.module("umbraco.resources")
    .factory("reportFactory", [
        "$http", function ($http) {
            var dataFactory = {};

            dataFactory.search = function (searchQuery) {
                return $http.post("backoffice/uJetSocial/ReportAPI/Search", searchQuery);
            };

            return dataFactory;
        }
    ]);