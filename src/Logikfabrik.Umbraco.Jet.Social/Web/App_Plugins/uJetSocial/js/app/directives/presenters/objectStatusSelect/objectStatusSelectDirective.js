angular.module("umbraco.directives")
    .directive("ujetObjectStatusSelect", [
        "_", "dialogService", "notificationsService", "guestFactory", "queryService",
        function (_, dialogService, notificationsService, guestFactory, queryService) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/objectStatusSelect/objectStatusSelectView.html",
                scope: {
                    ngModel: "="
                },
                link: function (scope, element, attrs) {
                    scope._ = _;

                    scope.$watch('ngModel', function () {

                    });
                }
            };
        }
    ]);