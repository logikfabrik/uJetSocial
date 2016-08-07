(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportCreateCtrl", ujetReportCreateCtrl);

    ujetReportCreateCtrl.$inject = ["$scope", "$controller", "$location", "notificationsService", "localService", "ujetReportFactory"];

    function ujetReportCreateCtrl($scope, $controller, $location, notificationsService, localService, ujetReportFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetReportFactory,
                path: "/uJetSocial/ujetReport/dashboard/-1",
                local: {
                    successCategory: "successCategoryAddReport",
                    success: "addReportSuccess",
                    errorCategory: "errorCategoryAddReport",
                    error: "addReportError"
                }
            }
        });
    };
})();