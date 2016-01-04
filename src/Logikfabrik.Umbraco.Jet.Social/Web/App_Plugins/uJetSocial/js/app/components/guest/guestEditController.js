angular.module("umbraco")
    .controller("uJetSocial.guestEditController", [
        "$scope", "$routeParams", "navigationService", "notificationsService", "guestFactory",
        function ($scope, $routeParams, navigationService, notificationsService, guestFactory) {
            guestFactory.get($routeParams.id)
                .success(function (data) {
                    $scope.model = data;

                    navigationService.syncTree({ tree: "guest", path: ["-1", data.FirstName.substr(0, 1).toLowerCase()], forceReload: false });
                })
                .error(function () {
                    notificationsService.error("Guest could not be edited");
                });

            $scope.save = function (form) {
                if (!form.$valid) {
                    return;
                }

                guestFactory.update($scope.model)
                    .success(function (data) {
                        notificationsService.success("Guest updated");

                        $scope.model = data;
                    })
                    .error(function () {
                        notificationsService.error("Guest could not be updated");
                    });
            };
        }
    ]);