angular.module('umbraco')
    .controller('uJetCommunity.CommentEditController', ['$scope', '$routeParams', '_', 'commentFactory', 'queryService',
        function ($scope, $routeParams, _, commentFactory, queryService) {
            $scope.search = function () {
                var query = $scope.searchQuery.getQuery();

                commentFactory.search(query).success(function (data) {
                    $scope.pagingModel = {
                        pageIndex: $scope.searchQuery.pageIndex.value,
                        pageSize: $scope.searchQuery.pageSize.value,
                        total: data.total
                    };

                    $scope.testmodel = {
                        columns: ['Id', 'Created', 'Updated', 'Status'],
                        rows: data.entities
                    };

                });
            };

            commentFactory.getPossibleOrders().success(function (data) {
                $scope.searchQuery = queryService.getQuery($routeParams, data);

                $scope.search();
            });

            $scope.$on('pageIndexChanged', function (e, pageIndex) {
                $scope.searchQuery.pageIndex.value = pageIndex;
                $scope.search();
            });
            
            
        }]);