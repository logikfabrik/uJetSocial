(function () {
    "use strict";

    angular
        .module("umbraco.resources")
        .factory("_", ujetLodashFactory);

    function ujetLodashFactory() {
        return window._;
    };
})();