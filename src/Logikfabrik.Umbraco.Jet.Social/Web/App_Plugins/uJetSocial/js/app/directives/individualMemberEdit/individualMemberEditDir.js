(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetIndividualMemberEdit", ujetIndividualMemberEditDir);

    function ujetIndividualMemberEditDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/individualMemberEdit/individualMemberEditView.html",
            scope: {
                model: "="
            },
            controller: "ujetIndividualMemberEditDirCtrl"
        };

        return directive;
    };
})();