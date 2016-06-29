(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportPickerDirCtrl", ujetReportPickerDirCtrl);

    ujetReportPickerDirCtrl.$inject = ["$scope", "$controller", "localizationService", "queryService", "ujetReportFactory"];

    function ujetReportPickerDirCtrl($scope, $controller, localizationService, queryService, ujetReportFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            localizationService: localizationService,
            queryService: queryService,
            config: {
                objectFactory: ujetReportFactory,
                objectParam: "Text"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();