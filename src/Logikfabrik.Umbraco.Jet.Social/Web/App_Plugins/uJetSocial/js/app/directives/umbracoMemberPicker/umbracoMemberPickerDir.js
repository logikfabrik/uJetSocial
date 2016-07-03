(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetUmbracoMemberPicker", ujetUmbracoMemberPickerDir);

    function ujetUmbracoMemberPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/umbracoMemberPicker/umbracoMemberPickerView.html",
            scope: true,
            controller: "ujetUmbracoMemberPickerDirCtrl"
        };

        return directive;
    };
})();