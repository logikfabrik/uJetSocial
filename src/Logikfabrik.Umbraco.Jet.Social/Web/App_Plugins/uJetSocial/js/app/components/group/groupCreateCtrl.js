(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupCreateCtrl", ujetGroupCreateCtrl);

    ujetGroupCreateCtrl.$inject = ["$scope", "$controller", "$location", "notificationsService", "localService", "ujetGroupFactory"];

    function ujetGroupCreateCtrl($scope, $controller, $location, notificationsService, localService, ujetGroupFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetGroupFactory,
                path: "/uJetSocial/ujetGroup/dashboard/-1",
                local: {
                    successCategory: "successCategoryAddGroup",
                    success: "addGroupSuccess",
                    errorCategory: "errorCategoryAddGroup",
                    error: "addGroupError"
                }
            }
        });
    };
})();