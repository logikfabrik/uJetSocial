(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportDashboardCtrl", ujetReportDashboardCtrl);

    ujetReportDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetReportDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "ujetReport", path: ["-1", $routeParams.id], forceReload: false });
    };
})();