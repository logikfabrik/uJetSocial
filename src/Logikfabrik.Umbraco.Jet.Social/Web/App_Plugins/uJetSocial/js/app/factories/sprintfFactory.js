(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("sprintf", ujetSprintfFactory);

    function ujetSprintfFactory() {
        return window.sprintf;
    };
})();