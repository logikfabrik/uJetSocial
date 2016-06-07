(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMediaDashboardCtrl", ujetMediaDashboardCtrl);

    ujetMediaDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "ujetMediaFactory"];

    function ujetMediaDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, ujetMediaFactory) {
        navigationService.syncTree({ tree: "ujetMedia", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetMediaFactory,
                successMessage: "Success",
                errorMessage: "Error"
            }
        });
    };
})();