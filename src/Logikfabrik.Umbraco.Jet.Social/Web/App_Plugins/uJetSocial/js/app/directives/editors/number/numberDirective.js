angular.module("umbraco.directives")
    .directive("ujetNumber", [
        function () {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/assets/js/app/directives/editors/number/numberView.html",
                scope: {
                    id: "@",
                    label: "@",
                    desciption: "@",
                    ngModel: "="
                },
                link: function (scope, element, attrs) {
                }
            };
        }
    ]);
