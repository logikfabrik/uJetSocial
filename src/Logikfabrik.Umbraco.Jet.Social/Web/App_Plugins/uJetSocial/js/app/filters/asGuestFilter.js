(function () {
    'use strict';

    angular
        .module("umbraco.resources")
        .filter("ujetAsGuest", ujetAsGuestFilter);

    function ujetAsGuestFilter() {
        return function (obj) {
            obj.label = "Guest";

            return obj;
        };
    };
})();