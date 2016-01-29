angular.module("umbraco")
    .controller("uJetSocial.guestListController", [
        "$scope", "$routeParams", "navigationService",
        function ($scope, $routeParams, navigationService) {

            $scope.params = {
                "FirstName": $routeParams.id
            };

            navigationService.syncTree({ tree: "guest", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);