(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualMemberDashboardCtrl", ujetIndividualMemberDashboardCtrl);

    ujetIndividualMemberDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "localService", "ujetIndividualMemberFactory"];

    function ujetIndividualMemberDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, localService, ujetIndividualMemberFactory) {
        navigationService.syncTree({ tree: "ujetIndividualMember", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetIndividualMemberFactory,
                local: {
                    successCategory: "uJetSocial_successCategoryUpdateMember",
                    success: "uJetSocial_updateMemberSuccess",
                    errorCategory: "uJetSocial_errorCategoryUpdateMember",
                    error: "uJetSocial_updateMemberError"
                }
            }
        });
    };
})();