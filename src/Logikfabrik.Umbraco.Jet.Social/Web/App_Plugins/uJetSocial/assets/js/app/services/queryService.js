angular.module('umbraco.services')
    .service('queryService', ['_', function (_) {
        function getParts(routeParams) {
            if (routeParams.id == -1)
                return [];

            return routeParams.id.split('-');
        }

        function getYear(routeParams, offset) {
            var parts = getParts(routeParams);

            if (_.isEmpty(parts))
                return new Date().getYear();

            var year = parseInt(_.first(parts));

            return !offset ? year : year + 1;
        }

        function getMonth(routeParams, offset) {
            var parts = getParts(routeParams);

            if (_.isEmpty(parts))
                return new Date().getMonth();

            var month = parts.length > 1 ? parseInt(_.last(parts)) - 1 : 0;

            return !offset ? month : month + 1;
        }

        function getFrom(routeParams) {
            var year = getYear(routeParams, false);
            var month = getMonth(routeParams, false);

            return new Date(Date.UTC(year, month, 1, 0, 0, 0));
        }

        function getTo(routeParams) {
            var parts = getParts(routeParams);
            
            var year = getYear(routeParams, !(parts.length > 1));
            var month = getMonth(routeParams, parts.length > 1);
            var hour = !(parts.length > 1) ? 0 : 24;

            return new Date(Date.UTC(year, month, 1, hour, 0, 0));
        }
        
        var dataService = {};

        dataService.getQuery = function (routeParams, possibleOrders) {
            var searchQuery = {};

            searchQuery.from = {
                value: getFrom(routeParams)
            };

            searchQuery.to = {
                value: getTo(routeParams)
            };

            searchQuery.pageIndex = {
                value: 15,
                min: 1
            };

            searchQuery.pageSize = {
                value: 20,
                min: 10,
                max: 100,
                step: 10
            };
            
            searchQuery.orderBy = {
                value: '',
                options: possibleOrders
            };

            searchQuery.getQuery = function() {
                return {
                    from: searchQuery.from.value,
                    to: searchQuery.to.value,
                    pageIndex: searchQuery.pageIndex.value - 1,
                    pageSize: searchQuery.pageSize.value
                };
            };
            
            return searchQuery;
        };

        return dataService;
    }]);