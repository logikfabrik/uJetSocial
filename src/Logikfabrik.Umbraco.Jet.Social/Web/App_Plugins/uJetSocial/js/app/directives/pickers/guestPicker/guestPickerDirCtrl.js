(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGuestPickerDirCtrl", ujetGuestPickerDirCtrl);

    ujetGuestPickerDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetGuestFactory"];

    function ujetGuestPickerDirCtrl($scope, $controller, queryService, ujetGuestFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetGuestFactory,
                objectParam: "FirstName"
            }
        });
    };
})();