(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDocumentPickerDirCtrl", ujetDocumentPickerDirCtrl);

    ujetDocumentPickerDirCtrl.$inject = ["$scope", "$controller"];

    function ujetDocumentPickerDirCtrl($scope, $controller) {
        $controller("ujetUmbracoPickerCtrl", {
            $scope: $scope
        });
    };
})();