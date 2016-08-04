(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualGuestPickerDirCtrl", ujetIndividualGuestPickerDirCtrl);

    ujetIndividualGuestPickerDirCtrl.$inject = ["$scope", "$controller", "notificationsService", "localService", "queryService", "ujetIndividualGuestFactory"];

    function ujetIndividualGuestPickerDirCtrl($scope, $controller, notificationsService, localService, queryService, ujetIndividualGuestFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            queryService: queryService,
            config: {
                objectFactory: ujetIndividualGuestFactory,
                objectParam: "FirstName"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();