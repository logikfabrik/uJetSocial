(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetReportList", ujetReportListDir);

    function ujetReportListDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/reportList/reportListView.html",
            scope: true,
            controller: "ujetReportListDirCtrl"
        };

        return directive;
    };
})();