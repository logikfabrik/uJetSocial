(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualGuestPickerDirCtrl", ujetIndividualGuestPickerDirCtrl);

    ujetIndividualGuestPickerDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetIndividualGuestFactory"];

    function ujetIndividualGuestPickerDirCtrl($scope, $controller, queryService, ujetIndividualGuestFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetIndividualGuestFactory,
                objectParam: "FirstName"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();