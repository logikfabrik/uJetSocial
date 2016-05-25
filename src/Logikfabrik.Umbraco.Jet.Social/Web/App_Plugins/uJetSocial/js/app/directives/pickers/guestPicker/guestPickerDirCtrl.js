(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGuestPickerDirCtrl", ujetGuestPickerDirCtrl);

    ujetGuestPickerDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetIndividualGuestFactory"];

    function ujetGuestPickerDirCtrl($scope, $controller, queryService, ujetIndividualGuestFactory) {
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