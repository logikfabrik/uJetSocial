(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGuestDashboardCtrl", ujetGuestDashboardCtrl);

    ujetGuestDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetGuestDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "individualGuest", path: ["-1", $routeParams.id], forceReload: false });
    };
})();