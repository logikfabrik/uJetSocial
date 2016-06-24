(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetUmbracoDocumentPickerDirCtrl", ujetUmbracoDocumentPickerDirCtrl);

    ujetUmbracoDocumentPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "queryService", "ujetUmbracoDocumentFactory"];

    function ujetUmbracoDocumentPickerDirCtrl($scope, $controller, $filter, queryService, ujetUmbracoDocumentFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoDocumentFactory,
                objectParam: "Name"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();