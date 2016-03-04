(function () {
    "use strict";

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
                path: "/uJetSocial/group/dashboard/-1",
                createSuccessMessage: "Group created",
                createErrorMessage: "Group could not be created"
            }
        });
    };
})();