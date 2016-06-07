(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsIndividualGuest", ujetAsIndividualGuestFilter);

    ujetAsIndividualGuestFilter.$inject = ["sprintf"];

    function ujetAsIndividualGuestFilter(sprintf) {
        return function (object) {
            object.label = sprintf("%(firstName)s %(lastName)s", object);
            object.subLabel = object.email;

            return object;
        };
    };
})();