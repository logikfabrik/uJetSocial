(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetDocumentPicker", ujetDocumentPickerDir);

    function ujetDocumentPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/documentPicker/documentPickerView.html",
            scope: true,
            controller: "ujetDocumentPickerDirCtrl"
        };

        return directive;
    };
})();