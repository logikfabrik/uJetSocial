(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportCreateCtrl", ujetReportCreateCtrl);

    ujetReportCreateCtrl.$inject = ["$scope", "$controller", "$location", "notificationsService", "ujetReportFactory"];

    function ujetReportCreateCtrl($scope, $controller, $location, notificationsService, ujetReportFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetReportFactory,
                path: "/uJetSocial/ujetReport/dashboard/-1",
                createSuccessMessage: "Report created",
                createErrorMessage: "Report could not be created"
            }
        });
    };
})();