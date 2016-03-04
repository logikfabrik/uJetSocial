﻿(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetReportDashboardCtrl", ujetReportDashboardCtrl);

    ujetReportDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetReportDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "report", path: ["-1", $routeParams.id], forceReload: false });
    };
})();