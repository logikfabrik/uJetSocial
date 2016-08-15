(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualGuestCreateCtrl", ujetIndividualGuestCreateCtrl);

    ujetIndividualGuestCreateCtrl.$inject = ["$scope", "$controller", "$location", "$route", "notificationsService", "localService", "ujetIndividualGuestFactory"];

    function ujetIndividualGuestCreateCtrl($scope, $controller, $location, $route, notificationsService, localService, ujetIndividualGuestFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            $route: $route,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetIndividualGuestFactory,
                path: "/uJetSocial/ujetIndividualGuest/dashboard/-1",
                local: {
                    successCategory: "uJetSocial_successCategoryAddGuest",
                    success: "uJetSocial_addGuestSuccess",
                    errorCategory: "uJetSocial_errorCategoryAddGuest",
                    error: "uJetSocial_addGuestError"
                }
            }
        });
    };
})();