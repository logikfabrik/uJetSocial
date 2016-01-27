angular.module("umbraco")
    .controller("uJetSocial.groupEditController", [
        "$scope", "$routeParams", "navigationService", "notificationsService", "groupFactory",
        function ($scope, $routeParams, navigationService, notificationsService, groupFactory) {
            groupFactory.get($routeParams.id)
                .success(function (data) {
                    $scope.model = data;

                    navigationService.syncTree({ tree: "group", path: ["-1", data.Name.substr(0, 1).toLowerCase()], forceReload: false });
                })
                .error(function () {
                    notificationsService.error("Group could not be edited");
                });

            $scope.save = function (form) {
                if (!form.$valid) {
                    return;
                }

                groupFactory.update($scope.model)
                    .success(function (data) {
                        notificationsService.success("Group updated");

                        $scope.model = data;
                    })
                    .error(function () {
                        notificationsService.error("Group could not be updated");
                    });
            };
        }
    ]);