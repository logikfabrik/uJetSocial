(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .filter("ujetAsIndividualMember", ujetAsIndividualMemberFilter);

    function ujetAsIndividualMemberFilter() {
        return function (obj) {
            obj.label = "Member from Umbraco";

            return obj;
        };
    };
})();