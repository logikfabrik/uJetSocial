(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentPickerDirCtrl", ujetCommentPickerDirCtrl);

    ujetCommentPickerDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetCommentFactory"];

    function ujetCommentPickerDirCtrl($scope, $controller, queryService, ujetCommentFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetCommentFactory,
                objectParam: "Text"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();