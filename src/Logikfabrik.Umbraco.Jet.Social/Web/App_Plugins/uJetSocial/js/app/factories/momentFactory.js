(function () {
    "use strict";

    angular
        .module("umbraco.resources")
        .factory("moment", ujetMomentFactory);

    function ujetMomentFactory() {
        return window.moment;
    };
})();