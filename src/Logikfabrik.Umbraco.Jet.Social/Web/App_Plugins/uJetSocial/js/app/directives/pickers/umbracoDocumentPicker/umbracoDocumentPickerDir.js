(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetUmbracoDocumentPicker", ujetUmbracoDocumentPickerDir);

    function ujetUmbracoDocumentPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/umbracoDocumentPicker/umbracoDocumentPickerView.html",
            scope: true,
            controller: "ujetUmbracoDocumentPickerDirCtrl"
        };

        return directive;
    };
})();