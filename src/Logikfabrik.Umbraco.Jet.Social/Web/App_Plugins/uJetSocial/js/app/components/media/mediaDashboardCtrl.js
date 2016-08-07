(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMediaDashboardCtrl", ujetMediaDashboardCtrl);

    ujetMediaDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "localService", "ujetMediaFactory"];

    function ujetMediaDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, localService, ujetMediaFactory) {
        navigationService.syncTree({ tree: "ujetMedia", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetMediaFactory,
                local: {
                    successCategory: "successCategoryUpdateMedia",
                    success: "updateMediaSuccess",
                    errorCategory: "errorCategoryUpdateMedia",
                    error: "updateMediaError"
                }
            }
        });
    };
})();