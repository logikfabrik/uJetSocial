(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsUmbracoDocument", ujetAsUmbracoDocumentFilter);

    function ujetAsUmbracoDocumentFilter() {
        return function (object) {
            object.label = object.name;
            object.subLabel = object.url;

            return object;
        };
    };
})();