angular.module("umbraco")
    .controller("uJetSocial.groupDashboardController", [
        "$scope", "$routeParams", "navigationService", "_", "groupFactory",
        function ($scope, $routeParams, navigationService, _, groupFactory) {

            navigationService.syncTree({ tree: "group", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);