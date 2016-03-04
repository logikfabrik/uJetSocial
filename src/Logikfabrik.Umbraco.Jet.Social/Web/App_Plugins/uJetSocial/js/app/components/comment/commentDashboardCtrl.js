(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetCommentDashboardCtrl", ujetCommentDashboardCtrl);

    ujetCommentDashboardCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetCommentDashboardCtrl($routeParams, navigationService) {
        navigationService.syncTree({ tree: "comment", path: ["-1", $routeParams.id], forceReload: false });
    };
})();