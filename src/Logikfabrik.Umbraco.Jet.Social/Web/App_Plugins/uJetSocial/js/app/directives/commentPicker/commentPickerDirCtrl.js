(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentPickerDirCtrl", ujetCommentPickerDirCtrl);

    ujetCommentPickerDirCtrl.$inject = ["$scope", "$controller", "notificationsService", "localService", "queryService", "ujetCommentFactory"];

    function ujetCommentPickerDirCtrl($scope, $controller, notificationsService, localService, queryService, ujetCommentFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            queryService: queryService,
            config: {
                objectFactory: ujetCommentFactory,
                objectParam: "Text"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();