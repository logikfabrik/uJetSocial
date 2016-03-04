(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetCommentDashboardController", ujetCommentDashboardController);

    ujetCommentDashboardController.$inject = ["$routeParams", "navigationService"];

    function ujetCommentDashboardController($routeParams, navigationService) {
        navigationService.syncTree({ tree: "comment", path: ["-1", $routeParams.id], forceReload: false });
    };
})();