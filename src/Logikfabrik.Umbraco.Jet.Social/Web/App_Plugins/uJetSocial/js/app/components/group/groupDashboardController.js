angular.module("umbraco")
    .controller("uJetSocial.groupDashboardController", [
        "$scope", "$routeParams", "navigationService",
        function ($scope, $routeParams, navigationService) {

            navigationService.syncTree({ tree: "group", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);