(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetGuestDashboardController", ujetGuestDashboardController);

    ujetGuestDashboardController.$inject = ["$routeParams", "navigationService"];

    function ujetGuestDashboardController($routeParams, navigationService) {
        navigationService.syncTree({ tree: "guest", path: ["-1", $routeParams.id], forceReload: false });
    };
})();