(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGuestCreateCtrl", ujetGuestCreateCtrl);

    ujetGuestCreateCtrl.$inject = ["$scope", "$controller", "$location", "notificationsService", "ujetGuestFactory"];

    function ujetGuestCreateCtrl($scope, $controller, $location, notificationsService, ujetGuestFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetGuestFactory,
                path: "/uJetSocial/guest/dashboard/-1",
                createSuccessMessage: "Guest created",
                createErrorMessage: "Guest could not be created"
            }
        });
    };
})();