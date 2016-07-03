(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetStatusPicker", ujetStatusPickerDir);

    function ujetStatusPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/statusPicker/statusPickerView.html",
            scope: {
                model: "="
            },
            controller: "ujetStatusPickerDirCtrl"
        };

        return directive;
    };
})();