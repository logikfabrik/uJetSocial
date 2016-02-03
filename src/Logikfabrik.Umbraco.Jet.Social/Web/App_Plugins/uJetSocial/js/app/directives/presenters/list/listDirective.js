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

                    scope.sortAscending = true;

                    scope.sort = function (column) {
                        scope.sortAscending = (scope.sortColumn === column) ? !scope.sortAscending : true;
                        scope.sortColumn = column;

                        scope.ngModel.Rows = _.sortBy(scope.ngModel.Rows, [column]).reverse();
                    };

                    scope.select = function (row) {
                        scope.$emit("selectedRowChanged", row);
                    };
                }
            };
        }
    ]);
