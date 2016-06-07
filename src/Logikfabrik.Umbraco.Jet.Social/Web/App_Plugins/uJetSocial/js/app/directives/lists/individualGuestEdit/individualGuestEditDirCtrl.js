(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualGuestEditDirCtrl", ujetIndividualGuestEditDirCtrl);

    ujetIndividualGuestEditDirCtrl.$inject = ["$scope", "$controller", "_"];

    function ujetIndividualGuestEditDirCtrl($scope, $controller, _) {
        $controller("ujetEditCtrl", {
            $scope: $scope,
            _: _
        });
    };
})();