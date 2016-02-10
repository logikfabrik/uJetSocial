(function () {
    'use strict';

    angular
        .module("umbraco.resources")
        .filter("ujetAsMember", ujetAsMemberFilter);

    function ujetAsMemberFilter() {
        return function (obj) {
            obj.label = "Member";

            return obj;
        };
    };
})();