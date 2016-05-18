(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsUmbracoDocument", ujetAsUmbracoDocumentFilter);

    function ujetAsUmbracoDocumentFilter() {
        return function (obj) {
            obj.label = obj.name;

            return obj;
        };
    };
})();