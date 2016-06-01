(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupCreateCtrl", ujetGroupCreateCtrl);

    ujetGroupCreateCtrl.$inject = ["$scope", "$controller", "$location", "notificationsService", "ujetGroupFactory"];

    function ujetGroupCreateCtrl($scope, $controller, $location, notificationsService, ujetGroupFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetGroupFactory,
                path: "/uJetSocial/ujetGroup/dashboard/-1",
                createSuccessMessage: "Group created",
                createErrorMessage: "Group could not be created"
            }
        });
    };
})();