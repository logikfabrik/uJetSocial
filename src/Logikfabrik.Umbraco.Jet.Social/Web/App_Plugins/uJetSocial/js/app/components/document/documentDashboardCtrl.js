(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDocumentDashboardCtrl", ujetDocumentDashboardCtrl);

    ujetDocumentDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "localService", "ujetDocumentFactory"];

    function ujetDocumentDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, localService, ujetDocumentFactory) {
        navigationService.syncTree({ tree: "ujetDocument", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetDocumentFactory,
                local: {
                    successCategory: "uJetSocial_successCategoryUpdateDocument",
                    success: "uJetSocial_updateDocumentSuccess",
                    errorCategory: "uJetSocial_errorCategoryUpdateDocument",
                    error: "uJetSocial_updateDocumentError"
                }
            }
        });
    };
})();