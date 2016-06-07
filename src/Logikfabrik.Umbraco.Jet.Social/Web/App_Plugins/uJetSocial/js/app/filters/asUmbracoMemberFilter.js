(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsUmbracoMember", ujetAsUmbracoMemberFilter);

    function ujetAsUmbracoMemberFilter() {
        return function (object) {
            object.label = object.name;

            return object;
        };
    };
})();