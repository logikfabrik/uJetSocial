﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportCreateCtrl", ujetReportCreateCtrl);

    ujetReportCreateCtrl.$inject = ["$scope", "$controller", "$location", "$route", "notificationsService", "localService", "ujetReportFactory"];

    function ujetReportCreateCtrl($scope, $controller, $location, $route, notificationsService, localService, ujetReportFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            $route: $route,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetReportFactory,
                path: "/uJetSocial/ujetReport/dashboard/-1",
                local: {
                    successCategory: "uJetSocial_successCategoryAddReport",
                    success: "uJetSocial_addReportSuccess",
                    errorCategory: "uJetSocial_errorCategoryAddReport",
                    error: "uJetSocial_addReportError"
                }
            }
        });
    };
})();