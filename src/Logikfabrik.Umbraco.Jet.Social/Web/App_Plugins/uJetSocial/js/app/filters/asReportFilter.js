(function () {
    "use strict";

    angular
        .module("umbraco.resources")
        .filter("ujetAsReport", ujetAsReportFilter);

    function ujetAsReportFilter() {
        return function (obj) {
            obj.label = "Report";

            return obj;
        };
    };
})();