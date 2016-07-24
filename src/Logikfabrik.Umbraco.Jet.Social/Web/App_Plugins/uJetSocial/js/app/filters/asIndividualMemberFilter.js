(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsIndividualMember", ujetAsIndividualMemberFilter);

    function ujetAsIndividualMemberFilter() {
        return function (object) {
            object.label = object.name;
            object.subLabel = object.email;

            return object;
        };
    };
})();