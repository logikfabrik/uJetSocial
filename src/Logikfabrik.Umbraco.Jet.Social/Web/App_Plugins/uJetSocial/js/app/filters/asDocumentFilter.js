(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsDocument", ujetAsDocumentFilter);

    function ujetAsDocumentFilter() {
        return function (obj) {
            obj.label = obj.name;

            return obj;
        };
    };
})();