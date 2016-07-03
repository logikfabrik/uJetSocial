(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetReportEdit", ujetReportEditDir);

    function ujetReportEditDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/reportEdit/reportEditView.html",
            scope: {
                model: "="
            },
            controller: "ujetReportEditDirCtrl"
        };

        return directive;
    };
})();