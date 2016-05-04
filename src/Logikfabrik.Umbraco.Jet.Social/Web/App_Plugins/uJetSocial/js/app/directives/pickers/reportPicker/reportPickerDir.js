(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetReportPicker", ujetReportPicker);

    function ujetReportPicker() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/reportPicker/reportPickerView.html",
            scope: true,
            controller: "ujetReportPickerDirCtrl"
        };

        return directive;
    };
})();