(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetReportPicker", ujetReportPickerDir);

    function ujetReportPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/reportPicker/reportPickerView.html",
            scope: true,
            controller: "ujetReportPickerDirCtrl"
        };

        return directive;
    };
})();