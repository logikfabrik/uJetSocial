angular.module("umbraco.directives")
    .directive("ujetList", [
        "_", function (_) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/assets/js/app/directives/presenters/list/listView.html",
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

                        scope.ngModel.rows = _.sortBy(scope.ngModel.rows, [column]);

                        if (!sortDescending) {
                            scope.ngModel.rows.reverse();
                        }
                    };
                }
            };
        }
    ]);
