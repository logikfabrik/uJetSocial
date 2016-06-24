(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetUmbracoMediaPicker", ujetUmbracoMediaPickerDir);

    function ujetUmbracoMediaPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/umbracoMediaPicker/umbracoMediaPickerView.html",
            scope: true,
            controller: "ujetUmbracoMediaPickerDirCtrl"
        };

        return directive;
    };
})();