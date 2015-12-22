angular.module("umbraco.directives")
    .directive("ujetListPaging", [
        "_", function (_) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/assets/js/app/directives/presenters/listPaging/listPagingView.html",
                scope: {
                    ngModel: "="
                },
                link: function (scope, element, attrs) {
                    scope.$watch("ngModel", function () {
                        if (!scope.ngModel) {
                            return;
                        }

                        scope.pageIndex = scope.ngModel.pageIndex;
                        scope.pageIndices = _.range(Math.ceil(scope.ngModel.total / scope.ngModel.pageSize));
                    });

                    scope.goToPreviousPage = function () {
                        scope.goToPage(scope.pageIndex - 1);
                    };

                    scope.goToNextPage = function () {
                        scope.goToPage(scope.pageIndex + 1);
                    };

                    scope.goToPage = function (pageIndex) {
                        if (pageIndex < 1 || pageIndex > scope.pageIndices.length) {
                            return;
                        }

                        scope.pageIndex = pageIndex;
                        scope.$emit("pageIndexChanged", pageIndex);
                    };
                }
            };
        }
    ]);
