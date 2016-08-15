(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupCreateCtrl", ujetGroupCreateCtrl);

    ujetGroupCreateCtrl.$inject = ["$scope", "$controller", "$location", "$route", "notificationsService", "localService", "ujetGroupFactory"];

    function ujetGroupCreateCtrl($scope, $controller, $location, $route, notificationsService, localService, ujetGroupFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            $route: $route,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetGroupFactory,
                path: "/uJetSocial/ujetGroup/dashboard/-1",
                local: {
                    successCategory: "uJetSocial_successCategoryAddGroup",
                    success: "uJetSocial_addGroupSuccess",
                    errorCategory: "uJetSocial_errorCategoryAddGroup",
                    error: "uJetSocial_addGroupError"
                }
            }
        });
    };
})();