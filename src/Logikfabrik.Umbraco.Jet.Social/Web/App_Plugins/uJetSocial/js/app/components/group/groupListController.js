angular.module("umbraco")
    .controller("uJetSocial.groupListController", [
        "$scope", "$location", "$routeParams", "navigationService", "groupFactory", "queryService",
        function($scope, $location, $routeParams, navigationService, groupFactory, queryService) {

            var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "Name", "Description", "OwnerId"]);

            function runQuery() {
                groupFactory.query(query.compile({ "FirstName": $routeParams.id })).success(function(data) {
                    $scope.Result =
                    {
                        Columns: query.OrderBy.Options,
                        Rows: data.Objects
                    };

                    $scope.Paging = {
                        PageIndex: query.PageIndex.Value,
                        PageCount: Math.ceil(data.Total / query.PageSize.Value)
                    };
                });
            };

            $scope.$on('pageIndexChanged', function (e, pageIndex) {
                query.PageIndex.Value = pageIndex;

                runQuery();
            });

            $scope.$on('selectedRowChanged', function (e, row) {
                $location.path("/uJetSocial/group/edit/" + row.Id);
            });

            runQuery();

            navigationService.syncTree({ tree: "group", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);