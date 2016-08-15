(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetLabelDirCtrl", ujetLabelDirCtrl);

    ujetLabelDirCtrl.$inject = ["$scope", "localService"];

    function ujetLabelDirCtrl($scope, localService) {
        var vm = {
            config: {
                local: localService.localize({
                    title: $scope.title,
                    description: $scope.description
                })
            }
        };

        $scope.vm = vm;
    };
})();