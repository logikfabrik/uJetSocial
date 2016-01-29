angular.module("umbraco.directives")
    .directive("ujetGuestList", [
        "$location", "guestFactory", "queryService",
        function ($location, guestFactory, queryService) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/guestList/guestListView.html",
                scope: {
                    ngModel: "="
                },
                link: function (scope, element, attrs) {

                    var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "FirstName", "LastName"]);

                    function runQuery() {
                        guestFactory.query(query.compile(scope.ngModel)).success(function (data) {
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
                        $location.path("/uJetSocial/guest/edit/" + row.Id);
                    });

                    runQuery();
                }
            };
        }
    ]);