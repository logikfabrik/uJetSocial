(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportDashboardCtrl", ujetReportDashboardCtrl);

    ujetReportDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "ujetReportFactory"];

    function ujetReportDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, ujetReportFactory) {
        navigationService.syncTree({ tree: "ujetReport", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetReportFactory,
                successMessage: "Success",
                errorMessage: "Error"
            }
        });
    };
})();