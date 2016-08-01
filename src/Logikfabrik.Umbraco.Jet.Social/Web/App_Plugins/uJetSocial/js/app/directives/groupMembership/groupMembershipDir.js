(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetGroupMembership", ujetGroupMembershipDir);

    function ujetGroupMembershipDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/groupMembership/groupMembershipView.html",
            scope: {
                model: "="
            },
            controller: "ujetGroupMembershipDirCtrl"
        };

        return directive;
    };
})();