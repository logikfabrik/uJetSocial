(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualGuestCreateCtrl", ujetIndividualGuestCreateCtrl);

    ujetIndividualGuestCreateCtrl.$inject = ["$scope", "$controller", "$location", "notificationsService", "localService", "ujetIndividualGuestFactory"];

    function ujetIndividualGuestCreateCtrl($scope, $controller, $location, notificationsService, localService, ujetIndividualGuestFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetIndividualGuestFactory,
                path: "/uJetSocial/ujetIndividualGuest/dashboard/-1",
                local: {
                    successCategory: "successCategoryAddGuest",
                    success: "addGuestSuccess",
                    errorCategory: "errorCategoryAddGuest",
                    error: "addGuestError"
                }
            }
        });
    };
})();