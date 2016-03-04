(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetReportDashboardController", ujetReportDashboardController);

    ujetReportDashboardController.$inject = ["$routeParams", "navigationService"];

    function ujetReportDashboardController($routeParams, navigationService) {
        navigationService.syncTree({ tree: "report", path: ["-1", $routeParams.id], forceReload: false });
    };
})();