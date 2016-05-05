(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsPage", ujetAsDocumentFilter);

    function ujetAsDocumentFilter() {
        return function (obj) {
            obj.label = "Document";

            return obj;
        };
    };
})();