(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentDashboardCtrl", ujetCommentDashboardCtrl);

    ujetCommentDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "localService", "ujetCommentFactory"];

    function ujetCommentDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, localService, ujetCommentFactory) {
        navigationService.syncTree({ tree: "ujetComment", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetCommentFactory,
                local: {
                    successCategory: "successCategoryUpdateComment",
                    success: "updateCommentSuccess",

                    errorCategory: "errorCategoryUpdateComment",
                    error: "updateCommentError"
                }
            }
        });
    };
})();