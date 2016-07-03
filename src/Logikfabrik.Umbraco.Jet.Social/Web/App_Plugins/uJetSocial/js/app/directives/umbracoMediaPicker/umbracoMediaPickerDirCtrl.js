(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetUmbracoMediaPickerDirCtrl", ujetUmbracoMediaPickerDirCtrl);

    ujetUmbracoMediaPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "localizationService", "queryService", "ujetUmbracoMediaFactory"];

    function ujetUmbracoMediaPickerDirCtrl($scope, $controller, $filter, localizationService, queryService, ujetUmbracoMediaFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            localizationService: localizationService,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMediaFactory,
                objectParam: "Name"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();