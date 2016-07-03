(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetTabDirCtrl", ujetTabDirCtrl);

    function ujetTabDirCtrl($scope) {
        var vm = {
            header: $scope.header,
            isActive: false
        };

        $scope.vm = vm;

        // TODO: Solve this!
        // $scope.$parent.vm.addTab(vm);
    };
})();