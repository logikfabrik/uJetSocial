(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualGuestDashboardCtrl", ujetIndividualGuestDashboardCtrl);

    ujetIndividualGuestDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetIndividualGuestDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "individualGuest", path: ["-1", $routeParams.id], forceReload: false });
    };
})();