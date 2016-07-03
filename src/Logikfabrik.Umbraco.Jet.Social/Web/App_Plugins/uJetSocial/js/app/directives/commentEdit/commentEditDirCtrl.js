(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentEditDirCtrl", ujetCommentEditDirCtrl);

    ujetCommentEditDirCtrl.$inject = ["$scope", "$controller", "_"];

    function ujetCommentEditDirCtrl($scope, $controller, _) {
        $controller("ujetEditCtrl", {
            $scope: $scope,
            _: _
        });
    };
})();