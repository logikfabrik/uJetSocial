(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsMedia", ujetAsMediaFilter);

    function ujetAsMediaFilter() {
        return function (obj) {
            obj.label = "Media";

            return obj;
        };
    };
})();