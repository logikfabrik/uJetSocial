(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsComment", ujetAsCommentFilter);

    function ujetAsCommentFilter() {
        return function (object) {
            object.label = "Comment";

            return object;
        };
    };
})();