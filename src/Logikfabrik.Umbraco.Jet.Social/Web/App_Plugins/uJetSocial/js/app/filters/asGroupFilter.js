(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsGroup", ujetAsGroupFilter);

    function ujetAsGroupFilter() {
        return function (obj) {
            obj.label = obj.name;

            return obj;
        };
    };
})();