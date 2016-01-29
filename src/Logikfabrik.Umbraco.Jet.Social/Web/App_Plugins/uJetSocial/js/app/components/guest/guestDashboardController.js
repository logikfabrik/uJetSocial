angular.module("umbraco")
    .controller("uJetSocial.guestDashboardController", [
        "$scope", "$routeParams", "navigationService",
        function ($scope, $routeParams, navigationService) {

            navigationService.syncTree({ tree: "guest", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);