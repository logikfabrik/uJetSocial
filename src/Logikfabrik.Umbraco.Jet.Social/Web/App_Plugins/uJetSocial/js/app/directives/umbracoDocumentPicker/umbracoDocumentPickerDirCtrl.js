(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetUmbracoDocumentPickerDirCtrl", ujetUmbracoDocumentPickerDirCtrl);

    ujetUmbracoDocumentPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "localizationService", "queryService", "ujetUmbracoDocumentFactory"];

    function ujetUmbracoDocumentPickerDirCtrl($scope, $controller, $filter, localizationService, queryService, ujetUmbracoDocumentFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            localizationService: localizationService,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoDocumentFactory,
                objectParam: "Name"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();