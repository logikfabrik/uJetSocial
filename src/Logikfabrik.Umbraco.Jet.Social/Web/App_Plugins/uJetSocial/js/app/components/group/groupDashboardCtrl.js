(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetGroupDashboardCtrl", ujetGroupDashboardCtrl);

    ujetGroupDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetGroupDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "group", path: ["-1", $routeParams.id], forceReload: false });
    };
})();