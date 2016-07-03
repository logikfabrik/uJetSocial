(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetGroupPicker", ujetGroupPickerDir);

    function ujetGroupPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/groupPicker/groupPickerView.html",
            scope: true,
            controller: "ujetGroupPickerDirCtrl"
        };

        return directive;
    };
})();