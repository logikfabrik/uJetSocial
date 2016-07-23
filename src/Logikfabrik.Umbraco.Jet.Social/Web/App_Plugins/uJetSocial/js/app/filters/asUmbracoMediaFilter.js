(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsUmbracoMedia", ujetAsUmbracoMediaFilter);

    function ujetAsUmbracoMediaFilter() {
        return function (object) {
            object.label = object.name;
            object.subLabel = object.url;

            return object;
        };
    };
})();