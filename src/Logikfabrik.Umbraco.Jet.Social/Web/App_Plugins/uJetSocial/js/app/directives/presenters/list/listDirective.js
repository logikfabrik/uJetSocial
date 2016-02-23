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
                    console.log("HEJ");
                    scope.sortAscending = true;

                    scope.sort = function (column) {
                        scope.sortAscending = (scope.sortColumn === column) ? !scope.sortAscending : true;
                        scope.sortColumn = column;

                        scope.ngModel.rows = _.sortBy(scope.ngModel.rows, [column]).reverse();
                    };

                    scope.select = function (row) {
                        scope.$emit("selectedRowChanged", row);
                    };

                    scope.getPropertyValue = function(row, column) {
                        console.log(column);
                        console.log(ngModel);


                        var propertyName = column.substr(0, 1).toLowerCase() + column.substr(1);

                        return _.property(propertyName)(row);
                    };
                }
            };
        }
    ]);
