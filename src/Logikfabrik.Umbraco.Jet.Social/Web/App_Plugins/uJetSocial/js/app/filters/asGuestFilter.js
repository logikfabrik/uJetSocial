(function () {
    "use strict";

    angular
        .module("umbraco.resources")
        .filter("ujetAsGuest", ujetAsGuestFilter);

    ujetAsGuestFilter.$inject = ["sprintf"];

    function ujetAsGuestFilter(sprintf) {
        return function (obj) {
            obj.label = sprintf("%(firstName)s %(lastName)s", obj);
            obj.subLabel = obj.email;

            return obj;
        };
    };
})();