angular.module("umbraco")
    .controller("uJetSocial.guestListController", [
        "$scope", "$routeParams", "navigationService", "guestFactory", "queryService",
        function($scope, $routeParams, navigationService, guestFactory, queryService) {

            var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "FirstName", "LastName"]);
            
            function runQuery() {
                guestFactory.query(query.compile({ "FirstName": $routeParams.id })).success(function (data) {
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

            runQuery();

            navigationService.syncTree({ tree: "guest", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);