angular.module('umbraco.resources')
    .factory('commentFactory', ['$http', function ($http) {
        var dataFactory = {};

        dataFactory.search = function (searchQuery) {
            return $http.post('backoffice/uJetCommunity/CommentsApi/Search', searchQuery);
        };

        dataFactory.getPossibleOrders = function() {
            return $http.get('backoffice/uJetCommunity/CommentsApi/GetPossibleOrders');
        };

        return dataFactory;
    }]);