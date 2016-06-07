(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetEditCtrl", ujetEditCtrl);

    function ujetEditCtrl($scope, _) {
        var vm = {
            save: save,
            cancel: close
        };

        $scope.vm = vm;

        function save(form) {
            if (!form.$valid) {
                return;
            }

            $scope.$emit("saveEdit", vm.object);
        };

        function close() {
            $scope.$emit("cancelEdit");
        };

        $scope.$watch("model", function (newValue) {
            vm.object = _.clone(newValue);
        });
    };
})();