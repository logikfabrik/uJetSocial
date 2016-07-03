(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetIndividualMemberList", ujetIndividualMemberListDir);

    function ujetIndividualMemberListDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/individualMemberList/individualMemberListView.html",
            scope: true,
            controller: "ujetIndividualMemberListDirCtrl"
        };

        return directive;
    };
})();