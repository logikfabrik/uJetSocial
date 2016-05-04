(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("moment", ujetMomentFactory);

    function ujetMomentFactory() {
        return window.moment;
    };
})();