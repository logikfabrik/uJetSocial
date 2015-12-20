angular.module("umbraco.directives")
    .directive("ujetDate", [
        function () {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/assets/js/app/directives/editors/date/dateView.html",
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
