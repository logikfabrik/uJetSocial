(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMediaDashboardCtrl", ujetMediaDashboardCtrl);

    ujetMediaDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetMediaDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "ujetMedia", path: ["-1", $routeParams.id], forceReload: false });
    };
})();