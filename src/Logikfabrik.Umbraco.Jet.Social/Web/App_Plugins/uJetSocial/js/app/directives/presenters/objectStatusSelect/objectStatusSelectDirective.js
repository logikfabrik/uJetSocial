angular.module("umbraco.directives")
    .directive("ujetObjectStatusSelect", [
        "_",
        function (_) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/objectStatusSelect/objectStatusSelectView.html",
                scope: {
                    ngModel: "="
                },
                link: function (scope, element, attrs) {
                    scope._ = _;
                }
            };
        }
    ]);