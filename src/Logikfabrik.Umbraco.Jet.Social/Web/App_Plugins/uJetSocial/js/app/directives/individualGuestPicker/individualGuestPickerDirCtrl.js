(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualGuestPickerDirCtrl", ujetIndividualGuestPickerDirCtrl);

    ujetIndividualGuestPickerDirCtrl.$inject = ["$scope", "$controller", "localizationService", "queryService", "ujetIndividualGuestFactory"];

    function ujetIndividualGuestPickerDirCtrl($scope, $controller, localizationService, queryService, ujetIndividualGuestFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            localizationService: localizationService,
            queryService: queryService,
            config: {
                objectFactory: ujetIndividualGuestFactory,
                objectParam: "FirstName"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();