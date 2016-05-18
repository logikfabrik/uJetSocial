(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsUmbracoMember", ujetAsUmbracoMemberFilter);

    function ujetAsUmbracoMemberFilter() {
        return function (obj) {
            obj.label = obj.name;

            return obj;
        };
    };
})();