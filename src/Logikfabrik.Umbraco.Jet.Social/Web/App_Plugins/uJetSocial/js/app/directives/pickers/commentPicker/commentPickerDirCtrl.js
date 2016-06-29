(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentPickerDirCtrl", ujetCommentPickerDirCtrl);

    ujetCommentPickerDirCtrl.$inject = ["$scope", "$controller", "localizationService", "queryService", "ujetCommentFactory"];

    function ujetCommentPickerDirCtrl($scope, $controller, localizationService, queryService, ujetCommentFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            localizationService: localizationService,
            queryService: queryService,
            config: {
                objectFactory: ujetCommentFactory,
                objectParam: "Text"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();