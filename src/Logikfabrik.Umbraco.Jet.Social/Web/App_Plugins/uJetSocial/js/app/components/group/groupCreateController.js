angular.module("umbraco")
    .controller("uJetSocial.groupCreateController", [
        "$scope", "$location", "notificationsService", "groupFactory",
        function ($scope, $location, notificationsService, groupFactory) {
            $scope.create = function (form) {
                if (!form.$valid) {
                    return;
                }

                groupFactory.add($scope.model)
                    .success(function (id) {
                        notificationsService.success("Group created");

                        $location.path("/uJetSocial/group/edit/" + id);

                        close();
                    })
                    .error(function () {
                        notificationsService.error("Group could not be created");
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