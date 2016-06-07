(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetReportEdit", ujetReportEdit);

    function ujetReportEdit() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/lists/reportEdit/reportEditView.html",
            scope: {
                model: "="
            },
            controller: "ujetReportEditDirCtrl"
        };

        return directive;
    };
})();