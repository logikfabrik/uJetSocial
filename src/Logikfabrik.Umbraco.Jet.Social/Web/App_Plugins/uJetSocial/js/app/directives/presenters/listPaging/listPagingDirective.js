angular.module("umbraco.directives")
    .directive("ujetListPaging", [
        "_",
        function (_) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/listPaging/listPagingView.html",
                scope: {
                    model: "="
                },
                link: function (scope, element, attrs) {
                    scope._ = _;

                    scope.goToFirstPage = function () {
                        scope.goToPage(1);
                    };

                    scope.goToPreviousPage = function () {
                        scope.goToPage(scope.model.pageIndex - 1);
                    };

                    scope.goToNextPage = function () {
                        scope.goToPage(scope.model.pageIndex + 1);
                    };

                    scope.goToLastPage = function () {
                        scope.goToPage(scope.model.pageCount);
                    };

                    scope.goToPage = function (pageIndex) {
                        if (pageIndex < 1 || pageIndex > scope.model.pageCount) {
                            return;
                        }

                        scope.$emit("pageIndexChanged", pageIndex);
                    };
                }
            };
        }
    ]);
