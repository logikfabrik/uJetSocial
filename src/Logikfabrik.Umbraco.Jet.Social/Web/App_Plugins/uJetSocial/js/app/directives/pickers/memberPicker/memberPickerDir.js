(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetMemberPicker", ujetMemberPickerDir);

    function ujetMemberPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/memberPicker/memberPickerView.html",
            scope: true,
            controller: "ujetMemberPickerDirCtrl"
        };

        return directive;
    };
})();