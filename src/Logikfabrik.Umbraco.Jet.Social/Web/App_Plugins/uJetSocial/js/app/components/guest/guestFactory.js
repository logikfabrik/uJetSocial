angular.module('umbraco.resources')
    .factory('guestFactory', ['$http', function ($http) {
        var dataFactory = {};

        dataFactory.search = function (searchQuery) {
            return $http.post('backoffice/uJetSocial/GuestApi/Search', searchQuery);
        };
        
        return dataFactory;
    }]);