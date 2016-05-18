(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsUmbracoMedia", ujetAsUmbracoMediaFilter);

    function ujetAsUmbracoMediaFilter() {
        return function (obj) {
            obj.label = obj.name;

            return obj;
        };
    };
})();