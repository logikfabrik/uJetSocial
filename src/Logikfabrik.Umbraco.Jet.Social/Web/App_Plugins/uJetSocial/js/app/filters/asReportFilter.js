(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsReport", ujetAsReportFilter);

    function ujetAsReportFilter() {
        return function (object) {
            object.label = "Report";

            return object;
        };
    };
})();