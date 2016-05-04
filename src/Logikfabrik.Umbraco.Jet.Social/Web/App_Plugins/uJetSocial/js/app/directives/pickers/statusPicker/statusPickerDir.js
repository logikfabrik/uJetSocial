(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetStatusPicker", ujetStatusPicker);

    function ujetStatusPicker() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/statusPicker/statusPickerView.html",
            scope: {
                model: "="
            },
            controller: "ujetStatusPickerDirCtrl"
        };

        return directive;
    };
})();