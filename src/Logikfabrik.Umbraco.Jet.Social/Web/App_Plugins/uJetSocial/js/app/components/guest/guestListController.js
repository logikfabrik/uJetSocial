angular.module("umbraco")
    .controller("uJetSocial.guestListController", [
        "$scope", "$routeParams", "navigationService", "_", "guestFactory",
        function ($scope, $routeParams, navigationService, _, guestFactory) {
            $scope.ngModel = {
                
            };

            $scope.query = {
                FirstName: "a",
                PageIndex: 0,
                PageSize: 15
            };

            guestFactory.query($scope.query).success(function (data) {
                console.log(data);

                $scope.ngModel = {
                    columns: ["Id", "Created", "Updated", "Status", "FirstName", "LastName"],
                    rows: data.Objects
                };
            });

            


            navigationService.syncTree({ tree: "guest", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);