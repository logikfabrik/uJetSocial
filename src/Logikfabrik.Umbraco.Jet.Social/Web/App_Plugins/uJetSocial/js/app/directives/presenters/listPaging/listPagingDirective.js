angular.module("umbraco.directives")
    .directive("ujetListPaging", [
        function() {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/listPaging/listPagingView.html",
                scope: {
                    ngModel: "="
                },
                link: function(scope, element, attrs) {
                    scope.goToFirstPage = function() {
                        scope.goToPage(0);
                    };

                    scope.goToPreviousPage = function() {
                        scope.goToPage(scope.ngModel.PageIndex - 1);
                    };

                    scope.goToNextPage = function() {
                        scope.goToPage(scope.ngModel.PageIndex + 1);
                    };

                    scope.goToLastPage = function() {
                        scope.goToPage(scope.ngModel.PageCount);
                    };

                    scope.goToPage = function(pageIndex) {
                        if (isNaN(pageIndex)) {
                            pageIndex = scope.ngModel.PageIndex;
                        }

                        if (pageIndex < 1 || pageIndex > scope.ngModel.PageCount || pageIndex === scope.ngModel.PageCount) {
                            return;
                        }

                        scope.$emit("pageIndexChanged", pageIndex);
                    };
                }
            };
        }
    ]);
