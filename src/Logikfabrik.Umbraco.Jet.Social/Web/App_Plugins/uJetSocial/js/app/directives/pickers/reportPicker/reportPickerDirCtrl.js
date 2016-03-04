(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetReportPickerDirCtrl", ujetReportPickerDirCtrl);

    ujetReportPickerDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetReportFactory"];

    function ujetReportPickerDirCtrl($scope, $controller, queryService, ujetReportFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetReportFactory,
                objectParam: "Text"
            }
        });
    };
})();