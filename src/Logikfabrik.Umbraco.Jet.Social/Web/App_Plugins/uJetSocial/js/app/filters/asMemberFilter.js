(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsMember", ujetAsMemberFilter);

    function ujetAsMemberFilter() {
        return function (obj) {
            obj.label = "Member from Umbraco";

            return obj;
        };
    };
})();