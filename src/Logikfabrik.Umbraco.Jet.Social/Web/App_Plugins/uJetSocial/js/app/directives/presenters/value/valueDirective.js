angular.module("umbraco.directives")
    .directive("ujetValue", [
        "moment",
        function (moment) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/value/valueView.html",
                scope: {
                    value: "@"
                },
                link: function (scope, element, attrs) {
                    scope.isDate = moment(scope.value, moment.ISO_8601, true).isValid();
                }
            };
        }
    ]);
