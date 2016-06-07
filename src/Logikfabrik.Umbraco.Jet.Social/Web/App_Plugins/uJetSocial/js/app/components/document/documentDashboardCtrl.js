(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDocumentDashboardCtrl", ujetDocumentDashboardCtrl);

    ujetDocumentDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "ujetDocumentFactory"];

    function ujetDocumentDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, ujetDocumentFactory) {
        navigationService.syncTree({ tree: "ujetDocument", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetDocumentFactory,
                successMessage: "Success",
                errorMessage: "Error"
            }
        });
    };
})();