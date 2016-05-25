(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetIndividualMemberPicker", ujetIndividualMemberPickerDir);

    function ujetIndividualMemberPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/individualMemberPicker/individualMemberPickerView.html",
            scope: true,
            controller: "ujetIndividualMemberPickerDirCtrl"
        };

        return directive;
    };
})();