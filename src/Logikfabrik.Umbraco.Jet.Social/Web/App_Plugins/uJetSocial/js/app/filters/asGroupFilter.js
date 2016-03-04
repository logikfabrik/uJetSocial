(function () {
    "use strict";

    angular
        .module("umbraco.resources")
        .filter("ujetAsGroup", ujetAsGroupFilter);

    function ujetAsGroupFilter() {
        return function (obj) {
            obj.label = obj.name;

            return obj;
        };
    };
})();