(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupDashboardCtrl", ujetGroupDashboardCtrl);

    ujetGroupDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "localService", "ujetGroupFactory"];

    function ujetGroupDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, localService, ujetGroupFactory) {
        navigationService.syncTree({ tree: "ujetGroup", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetGroupFactory,
                local: {
                    successCategory: "successCategoryUpdateGroup",
                    success: "updateGroupSuccess",
                    errorCategory: "errorCategoryUpdateGroup",
                    error: "updateGroupError"
                }
            }
        });
    };
})();