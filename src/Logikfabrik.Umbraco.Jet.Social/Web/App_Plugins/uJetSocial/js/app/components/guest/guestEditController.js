angular.module("umbraco")
    .controller("uJetSocial.guestEditController", [
        "$scope", "$routeParams", "navigationService", "notificationsService", "_", "guestFactory",
        function ($scope, $routeParams, navigationService, notificationsService, _, guestFactory) {
            guestFactory.get($routeParams.id)
                .success(function(data) {
                    $scope.model = data;

                    navigationService.syncTree({ tree: "guest", path: ["-1", data.FirstName.substr(0, 1).toLowerCase()], forceReload: false });
                })
                .error(function() {
                    notificationsService.error("Guest could not be edited");
                });


            
        }
    ]);