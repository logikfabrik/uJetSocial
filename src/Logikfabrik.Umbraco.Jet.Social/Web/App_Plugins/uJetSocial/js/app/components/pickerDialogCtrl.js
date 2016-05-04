(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetPickerDialogCtrl", ujetPickerDialogCtrl);

    ujetPickerDialogCtrl.$inject = ["$scope"];

    function ujetPickerDialogCtrl($scope) {
        var vm = this;

        vm.cancel = close;

        function close() {
            /*
             * The picker dialog is opened from the object picker, which passes its
             * options on using the current scope. The picker dialog in turn uses one of
             * the picker directives (in its template) to display the actual picker.
             *
             * Knowing this we can access the options and call the callback. Calling
             * the callback without specifying an object will make the object picker
             * to close the current picker dialog, without picking an object.
             */
            $scope.dialogOptions.callback(null);
        };
    };
})();