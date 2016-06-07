(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsDocument", ujetAsDocumentFilter);

    function ujetAsDocumentFilter() {
        return function (object) {
            object.label = "Document from Umbraco";

            return object;
        };
    };
})();