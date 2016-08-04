(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetUmbracoDocumentPickerDirCtrl", ujetUmbracoDocumentPickerDirCtrl);

    ujetUmbracoDocumentPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "notificationsService", "localService", "queryService", "ujetUmbracoDocumentFactory"];

    function ujetUmbracoDocumentPickerDirCtrl($scope, $controller, $filter, notificationsService, localService, queryService, ujetUmbracoDocumentFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoDocumentFactory,
                objectParam: "Name"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();