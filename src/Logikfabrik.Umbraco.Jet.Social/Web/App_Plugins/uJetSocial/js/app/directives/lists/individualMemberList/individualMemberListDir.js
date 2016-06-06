(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetIndividualMemberList", ujetIndividualMemberList);

    function ujetIndividualMemberList() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/lists/individualMemberList/individualMemberListView.html",
            scope: true,
            controller: "ujetIndividualMemberListDirCtrl"
        };

        return directive;
    };
})();