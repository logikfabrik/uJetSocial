(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupPickerDirCtrl", ujetGroupPickerDirCtrl);

    ujetGroupPickerDirCtrl.$inject = ["$scope", "$controller", "localizationService", "queryService", "ujetGroupFactory"];

    function ujetGroupPickerDirCtrl($scope, $controller, localizationService, queryService, ujetGroupFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            localizationService: localizationService,
            queryService: queryService,
            config: {
                objectFactory: ujetGroupFactory,
                objectParam: "Name"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();