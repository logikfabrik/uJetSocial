angular.module("umbraco.resources")
    .factory("commentFactory", [
        "$http", function ($http) {
            var dataFactory = {};

            dataFactory.search = function (searchQuery) {
                return $http.post("backoffice/uJetSocial/CommentAPI/Search", searchQuery);
            };

            return dataFactory;
        }
    ]);