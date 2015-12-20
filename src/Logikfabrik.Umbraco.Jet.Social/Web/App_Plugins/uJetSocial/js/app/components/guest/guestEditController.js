angular.module("umbraco")
    .controller("uJetSocial.guestEditController", [
        "$scope", "$routeParams", "navigationService", "_", "guestFactory",
        function ($scope, $routeParams, navigationService, _, guestFactory) {

            navigationService.syncTree({ tree: "guest", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);