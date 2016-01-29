angular.module("umbraco.directives")
    .directive("ujetGroupList", [
        "$location", "groupFactory", "queryService",
        function ($location, groupFactory, queryService) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/groupList/groupListView.html",
                scope: {
                    ngModel: "="
                },
                link: function (scope, element, attrs) {

                    var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "Name", "Description", "OwnerId"]);

                    function runQuery() {
                        groupFactory.query(query.compile(scope.ngModel)).success(function (data) {
                            scope.Result =
                            {
                                Columns: query.OrderBy.Options,
                                Rows: data.Objects
                            };

                            scope.Paging = {
                                PageIndex: query.PageIndex.Value,
                                PageCount: Math.ceil(data.Total / query.PageSize.Value)
                            };
                        });
                    };

                    scope.$on("pageIndexChanged", function (e, pageIndex) {
                        query.PageIndex.Value = pageIndex;

                        runQuery();
                    });

                    scope.$on("selectedRowChanged", function (e, row) {
                        $location.path("/uJetSocial/group/edit/" + row.Id);
                    });

                    runQuery();
                }
            };
        }
    ]);