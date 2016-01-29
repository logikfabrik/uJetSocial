angular.module("umbraco.directives")
    .directive("ujetList", [
        "_",
        function (_) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/list/listView.html",
                scope: {
                    ngModel: "="
                },
                link: function (scope, element, attrs) {
                    scope._ = _;

                    scope.SortAscending = true;

                    scope.sort = function (column) {
                        scope.SortAscending = (scope.SortColumn === column) ? !scope.SortAscending : true;
                        scope.SortColumn = column;

                        scope.ngModel.Rows = _.sortBy(scope.ngModel.Rows, [column]);

                        if (!scope.SortAscending) {
                            scope.ngModel.Rows.reverse();
                        }
                    };

                    scope.select = function (row) {
                        scope.$emit("selectedRowChanged", row);
                    };
                }
            };
        }
    ]);
