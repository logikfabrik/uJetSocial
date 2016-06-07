(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMediaEditDirCtrl", ujetMediaEditDirCtrl);

    ujetMediaEditDirCtrl.$inject = ["$scope", "$controller", "_"];

    function ujetMediaEditDirCtrl($scope, $controller, _) {
        $controller("ujetEditCtrl", {
            $scope: $scope,
            _: _
        });
    };
})();