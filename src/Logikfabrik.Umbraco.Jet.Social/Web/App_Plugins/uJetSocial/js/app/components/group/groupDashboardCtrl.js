(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupDashboardCtrl", ujetGroupDashboardCtrl);

    ujetGroupDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "ujetGroupFactory"];

    function ujetGroupDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, ujetGroupFactory) {
        navigationService.syncTree({ tree: "ujetGroup", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetGroupFactory,
                successMessage: "Success",
                errorMessage: "Error"
            }
        });
    };
})();