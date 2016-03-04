(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetGuestDashboardCtrl", ujetGuestDashboardCtrl);

    ujetGuestDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetGuestDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "guest", path: ["-1", $routeParams.id], forceReload: false });
    };
})();