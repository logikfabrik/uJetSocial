﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportDashboardCtrl", ujetReportDashboardCtrl);

    ujetReportDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "localService", "ujetReportFactory"];

    function ujetReportDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, localService, ujetReportFactory) {
        navigationService.syncTree({ tree: "ujetReport", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetReportFactory,
                local: {
                    successCategory: "uJetSocial_successCategoryUpdateReport",
                    success: "uJetSocial_updateReportSuccess",
                    errorCategory: "uJetSocial_errorCategoryUpdateReport",
                    error: "uJetSocial_updateReportError"
                }
            }
        });
    };
})();