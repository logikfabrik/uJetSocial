(function () {
    'use strict';

    angular
        .module("umbraco.resources")
        .filter("ujetAsGroup", ujetAsGroupFilter);

    ujetAsGroupFilter.$inject = ["_"];

    function ujetAsGroupFilter(_) {
        return function (obj) {
            obj.label = "Group";

            return obj;
        };
    };
})();