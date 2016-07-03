(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDocumentEditDirCtrl", ujetDocumentEditDirCtrl);

    ujetDocumentEditDirCtrl.$inject = ["$scope", "$controller", "_"];

    function ujetDocumentEditDirCtrl($scope, $controller, _) {
        $controller("ujetEditCtrl", {
            $scope: $scope,
            _: _
        });
    };
})();