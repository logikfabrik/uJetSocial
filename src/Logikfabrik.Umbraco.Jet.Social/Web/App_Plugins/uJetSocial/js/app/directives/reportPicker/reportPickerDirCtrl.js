(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportPickerDirCtrl", ujetReportPickerDirCtrl);

    ujetReportPickerDirCtrl.$inject = ["$scope", "$controller", "notificationsService", "localService", "queryService", "ujetReportFactory"];

    function ujetReportPickerDirCtrl($scope, $controller, notificationsService, localService, queryService, ujetReportFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            queryService: queryService,
            config: {
                objectFactory: ujetReportFactory,
                objectParam: "Text"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();