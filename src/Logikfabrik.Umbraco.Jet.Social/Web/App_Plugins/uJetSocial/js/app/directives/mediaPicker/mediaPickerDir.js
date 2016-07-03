(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetMediaPicker", ujetMediaPickerDir);

    function ujetMediaPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/mediaPicker/mediaPickerView.html",
            scope: true,
            controller: "ujetMediaPickerDirCtrl"
        };

        return directive;
    };
})();