angular.module("umbraco.directives")
    .directive("ujetList", [
        "_", function (_) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/list/listView.html",
                scope: {
                    ngModel: "="
                },
                transclude: true,
                link: function (scope, element, attrs) {
                    scope._ = _;

                    var sortDescending = true;
                    var sortColumn;

                    scope.sort = function (column) {
                        sortDescending = (sortColumn === column) ? !sortDescending : true;
                        sortColumn = column;

                        scope.ngModel.Rows = _.sortBy(scope.ngModel.Rows, [column]);

                        if (!sortDescending) {
                            scope.ngModel.Rows.reverse();
                        }
                    };
                }
            };
        }
    ]);
