angular.module('umbraco.resources')
    .factory('commentFactory', ['$http', function ($http) {
        var dataFactory = {};

        dataFactory.search = function (searchQuery) {
            return $http.post('backoffice/uJetSocial/CommentsApi/Search', searchQuery);
        };

        dataFactory.getPossibleOrders = function() {
            return $http.get('backoffice/uJetSocial/CommentsApi/GetPossibleOrders');
        };

        return dataFactory;
    }]);