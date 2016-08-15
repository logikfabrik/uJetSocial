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
                    successCategory: "uJetSocial_successCategoryUpdateComment",
                    success: "uJetSocial_updateCommentSuccess",
                    errorCategory: "uJetSocial_errorCategoryUpdateComment",
                    error: "uJetSocial_updateCommentError"
                }
            }
        });
    };
})();