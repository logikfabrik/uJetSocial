(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualMemberEditDirCtrl", ujetIndividualMemberEditDirCtrl);

    ujetIndividualMemberEditDirCtrl.$inject = ["$scope", "$controller", "_"];

    function ujetIndividualMemberEditDirCtrl($scope, $controller, _) {
        $controller("ujetEditCtrl", {
            $scope: $scope,
            _: _
        });
    };
})();