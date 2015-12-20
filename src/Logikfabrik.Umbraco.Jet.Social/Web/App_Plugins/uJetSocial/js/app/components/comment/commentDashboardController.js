angular.module("umbraco")
    .controller("uJetSocial.commentDashboardController", [
        "$scope", "$routeParams", "navigationService", "_", "commentFactory",
        function ($scope, $routeParams, navigationService, _, commentFactory) {

            navigationService.syncTree({ tree: "comment", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);