(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportEditDirCtrl", ujetReportEditDirCtrl);

    ujetReportEditDirCtrl.$inject = ["$scope", "$controller", "_"];

    function ujetReportEditDirCtrl($scope, $controller, _) {
        $controller("ujetEditCtrl", {
            $scope: $scope,
            _: _
        });
    };
})();