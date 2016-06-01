(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualMemberDashboardCtrl", ujetIndividualMemberDashboardCtrl);

    ujetIndividualMemberDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetIndividualMemberDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "ujetIndividualMember", path: ["-1", $routeParams.id], forceReload: false });
    };
})();