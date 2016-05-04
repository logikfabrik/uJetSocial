(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsPage", ujetAsPageFilter);

    function ujetAsPageFilter() {
        return function (obj) {
            obj.label = "Page";

            return obj;
        };
    };
})();