(function () {
    'use strict';

    angular
        .module("umbraco.resources")
        .filter("ujetAsPage", ujetAsPageFilter);

    function ujetAsPageFilter() {
        return function (obj) {
            obj.label = "Page";

            return obj;
        };
    };
})();