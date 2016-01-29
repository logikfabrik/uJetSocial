angular.module("umbraco")
    .controller("uJetSocial.groupListController", [
        "$scope", "$routeParams", "navigationService",
        function ($scope, $routeParams, navigationService) {

            $scope.params = {
                "Name": $routeParams.id
            };

            navigationService.syncTree({ tree: "group", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);