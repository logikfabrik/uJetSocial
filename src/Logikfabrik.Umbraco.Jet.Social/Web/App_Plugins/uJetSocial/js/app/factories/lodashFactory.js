(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("_", ujetLodashFactory);

    function ujetLodashFactory() {
        return window._;
    };
})();