(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentDashboardCtrl", ujetCommentDashboardCtrl);

    ujetCommentDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetCommentDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "ujetComment", path: ["-1", $routeParams.id], forceReload: false });
    };
})();