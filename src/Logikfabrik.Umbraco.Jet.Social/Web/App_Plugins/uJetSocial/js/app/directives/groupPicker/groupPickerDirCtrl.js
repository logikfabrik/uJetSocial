(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupPickerDirCtrl", ujetGroupPickerDirCtrl);

    ujetGroupPickerDirCtrl.$inject = ["$scope", "$controller", "notificationsService", "localService", "queryService", "ujetGroupFactory"];

    function ujetGroupPickerDirCtrl($scope, $controller, notificationsService, localService, queryService, ujetGroupFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            queryService: queryService,
            config: {
                objectFactory: ujetGroupFactory,
                objectParam: "Name"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();