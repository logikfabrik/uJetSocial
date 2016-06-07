(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualMemberDashboardCtrl", ujetIndividualMemberDashboardCtrl);

    ujetIndividualMemberDashboardCtrl.$inject = ["$scope", "$controller", "$routeParams", "navigationService", "notificationsService", "ujetIndividualMemberFactory"];

    function ujetIndividualMemberDashboardCtrl($scope, $controller, $routeParams, navigationService, notificationsService, ujetIndividualMemberFactory) {
        navigationService.syncTree({ tree: "ujetIndividualMember", path: ["-1", $routeParams.id], forceReload: false });

        $controller("ujetDashboardCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetIndividualMemberFactory,
                successMessage: "Success",
                errorMessage: "Error"
            }
        });
    };
})();