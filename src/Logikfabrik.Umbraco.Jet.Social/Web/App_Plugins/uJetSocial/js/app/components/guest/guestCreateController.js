angular.module("umbraco")
    .controller("uJetSocial.guestCreateController", [
        "$scope", "$location", "notificationsService", "guestFactory",
        function ($scope, $location, notificationsService, guestFactory) {
            $scope.create = function (form) {
                if (!form.$valid) {
                    return;
                }

                guestFactory.add($scope.model)
                    .success(function (id) {
                        notificationsService.success("Guest created");

                        $location.path("/uJetSocial/guest/dashboard/-1");

                        close();
                    })
                    .error(function () {
                        notificationsService.error("Guest could not be created");
                    });
            };

            $scope.cancel = function () {
                close();
            };

            function close() {
                /*
                 * We cannot use the dialog service, as it doesn't allow the dialog to be closed gracefully.
                 * As a hack we emit an internal event that Umbraco handles.
                */
                $scope.$emit("app.closeDialogs", undefined);
            };
        }
    ]);