angular.module("umbraco")
    .controller("uJetSocial.guestListController", [
        "$scope", "$routeParams", "navigationService", "guestFactory",
        function ($scope, $routeParams, navigationService, guestFactory) {
            $scope.query = {
                FirstName: $routeParams.id,
                PageIndex: 0,
                PageSize: 15
            };

            guestFactory.query($scope.query).success(function (data) {
                $scope.ngModel = {
                    columns: ["Id", "Created", "Updated", "Status", "FirstName", "LastName"],
                    rows: data.Objects
                };
            });

            navigationService.syncTree({ tree: "guest", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);