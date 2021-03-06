﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualGuestDashboardCtrl", ujetIndividualGuestDashboardCtrl);

    ujetIndividualGuestDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "localService", "ujetIndividualGuestFactory"];

    function ujetIndividualGuestDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, localService, ujetIndividualGuestFactory) {
        navigationService.syncTree({ tree: "ujetIndividualGuest", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetIndividualGuestFactory,
                local: {
                    successCategory: "uJetSocial_successCategoryUpdateGuest",
                    success: "uJetSocial_updateGuestSuccess",
                    errorCategory: "uJetSocial_errorCategoryUpdateGuest",
                    error: "uJetSocial_updateGuestError"
                }
            }
        });
    };
})();