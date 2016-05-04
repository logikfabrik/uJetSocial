(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetObjectEditCtrl", ujetObjectEditCtrl);

    ujetObjectEditCtrl.$inject = ["$scope", "_"];

    function ujetObjectEditCtrl($scope, _) {
        var vm = this;

        vm.object = _.clone($scope.dialogData);
        vm.save = save;
        vm.cancel = close;

        function save(form) {
            if (!form.$valid) {
                return;
            }

            $scope.dialogOptions.callback(vm.object);
        };

        function close() {
            /*
             * We cannot use the dialog service, as it doesn't allow the dialog to be closed gracefully.
             * As a hack we emit an internal event that Umbraco handles.
             */
            $scope.$emit("app.closeDialogs", undefined);
        };
    };
})();