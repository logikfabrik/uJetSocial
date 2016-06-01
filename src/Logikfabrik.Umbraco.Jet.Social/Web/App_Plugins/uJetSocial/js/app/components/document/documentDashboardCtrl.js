(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDocumentDashboardCtrl", ujetDocumentDashboardCtrl);

    ujetDocumentDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetDocumentDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "ujetDocument", path: ["-1", $routeParams.id], forceReload: false });
    };
})();