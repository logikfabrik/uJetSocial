(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupDashboardCtrl", ujetGroupDashboardCtrl);

    ujetGroupDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetGroupDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "ujetGroup", path: ["-1", $routeParams.id], forceReload: false });
    };
})();