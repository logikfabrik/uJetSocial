(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetGroupDashboardController", ujetGroupDashboardController);

    ujetGroupDashboardController.$inject = ["$routeParams", "navigationService"];

    function ujetGroupDashboardController($routeParams, navigationService) {
        navigationService.syncTree({ tree: "group", path: ["-1", $routeParams.id], forceReload: false });
    };
})();