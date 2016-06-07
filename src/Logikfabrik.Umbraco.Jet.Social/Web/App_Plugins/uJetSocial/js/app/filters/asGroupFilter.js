(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsGroup", ujetAsGroupFilter);

    function ujetAsGroupFilter() {
        return function (object) {
            object.label = object.name;

            return object;
        };
    };
})();