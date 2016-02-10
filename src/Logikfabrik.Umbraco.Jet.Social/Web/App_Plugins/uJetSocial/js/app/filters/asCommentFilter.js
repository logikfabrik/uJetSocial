(function () {
    'use strict';

    angular
        .module("umbraco.resources")
        .filter("ujetAsComment", ujetAsCommentFilter);

    function ujetAsCommentFilter() {
        return function (obj) {
            obj.label = "Comment";

            return obj;
        };
    };
})();