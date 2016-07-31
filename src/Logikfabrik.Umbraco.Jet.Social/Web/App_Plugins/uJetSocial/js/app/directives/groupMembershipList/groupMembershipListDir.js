(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetGroupMembershipList", ujetGroupMembershipListDir);

    function ujetGroupMembershipListDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/groupMembershipList/groupMembershipListView.html",
            scope: true,
            controller: "ujetGroupMembershipListDirCtrl"
        };

        return directive;
    };
})();