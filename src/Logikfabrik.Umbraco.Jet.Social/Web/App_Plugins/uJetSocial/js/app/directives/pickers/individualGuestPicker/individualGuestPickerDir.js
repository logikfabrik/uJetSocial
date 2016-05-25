(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetIndividualGuestPicker", ujetIndividualGuestPickerDir);

    function ujetIndividualGuestPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/individualGuestPicker/individualGuestPickerView.html",
            scope: true,
            controller: "ujetIndividualGuestPickerDirCtrl"
        };

        return directive;
    };
})();