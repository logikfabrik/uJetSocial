angular.module("umbraco")
    .controller("uJetSocial.groupListController", [
        "$scope", "$routeParams", "navigationService", "groupFactory",
        function ($scope, $routeParams, navigationService, groupFactory) {
            $scope.query = {
                FirstName: $routeParams.id,
                PageIndex: 0,
                PageSize: 15,
                OrderBy: 'Id'
            };

            groupFactory.query($scope.query).success(function (data) {
                $scope.ngModel = {
                    columns: ["Id", "Created", "Updated", "Status", "Name", "Description", "OwnerId"],
                    rows: data.Objects
                };
            });

            navigationService.syncTree({ tree: "group", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);