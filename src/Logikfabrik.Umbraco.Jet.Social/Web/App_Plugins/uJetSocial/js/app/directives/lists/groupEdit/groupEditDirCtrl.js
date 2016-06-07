(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupEditDirCtrl", ujetGroupEditDirCtrl);

    ujetGroupEditDirCtrl.$inject = ["$scope", "$controller", "_"];

    function ujetGroupEditDirCtrl($scope, $controller, _) {
        $controller("ujetEditCtrl", {
            $scope: $scope,
            _: _
        });
    };
})();