(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentDashboardCtrl", ujetCommentDashboardCtrl);

    ujetCommentDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "ujetCommentFactory"];

    function ujetCommentDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, ujetCommentFactory) {
        navigationService.syncTree({ tree: "ujetComment", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetCommentFactory,
                successMessage: "Success",
                errorMessage: "Error"
            }
        });
    };
})();