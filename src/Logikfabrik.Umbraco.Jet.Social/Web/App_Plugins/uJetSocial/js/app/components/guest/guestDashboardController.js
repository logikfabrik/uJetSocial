angular.module("umbraco")
    .controller("uJetSocial.guestDashboardController", [
        "$scope", "$routeParams", "navigationService", "_", "guestFactory",
        function ($scope, $routeParams, navigationService, _, guestFactory) {

            navigationService.syncTree({ tree: "guest", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);