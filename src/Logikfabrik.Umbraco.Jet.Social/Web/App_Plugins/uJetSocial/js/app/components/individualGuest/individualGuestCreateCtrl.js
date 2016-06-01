(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualGuestCreateCtrl", ujetIndividualGuestCreateCtrl);

    ujetIndividualGuestCreateCtrl.$inject = ["$scope", "$controller", "$location", "notificationsService", "ujetIndividualGuestFactory"];

    function ujetIndividualGuestCreateCtrl($scope, $controller, $location, notificationsService, ujetIndividualGuestFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetIndividualGuestFactory,
                path: "/uJetSocial/ujetIndividualGuest/dashboard/-1",
                createSuccessMessage: "Guest created",
                createErrorMessage: "Guest could not be created"
            }
        });
    };
})();