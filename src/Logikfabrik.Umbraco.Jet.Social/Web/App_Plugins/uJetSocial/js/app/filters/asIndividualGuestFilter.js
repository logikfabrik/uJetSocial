(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsIndividualGuest", ujetAsIndividualGuestFilter);

    ujetAsIndividualGuestFilter.$inject = ["sprintf"];

    function ujetAsIndividualGuestFilter(sprintf) {
        return function (obj) {
            obj.label = sprintf("%(firstName)s %(lastName)s", obj);
            obj.subLabel = obj.email;

            return obj;
        };
    };
})();