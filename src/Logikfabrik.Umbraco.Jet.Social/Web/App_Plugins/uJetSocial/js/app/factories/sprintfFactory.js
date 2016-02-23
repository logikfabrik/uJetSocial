(function () {
    'use strict';

    angular
        .module("umbraco.resources")
        .factory("sprintf", ujetSprintfFactory);

    function ujetSprintfFactory() {
        return window.sprintf;
    };
})();