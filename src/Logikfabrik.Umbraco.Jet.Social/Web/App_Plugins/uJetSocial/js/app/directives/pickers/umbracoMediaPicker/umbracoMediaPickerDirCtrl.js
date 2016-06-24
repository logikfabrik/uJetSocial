(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetUmbracoMediaPickerDirCtrl", ujetUmbracoMediaPickerDirCtrl);

    ujetUmbracoMediaPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "queryService", "ujetUmbracoMediaFactory"];

    function ujetUmbracoMediaPickerDirCtrl($scope, $controller, $filter, queryService, ujetUmbracoMediaFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMediaFactory,
                objectParam: "Name"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();