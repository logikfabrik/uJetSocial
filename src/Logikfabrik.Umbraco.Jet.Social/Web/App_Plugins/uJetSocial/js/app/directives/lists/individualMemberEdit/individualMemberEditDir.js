(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetIndividualMemberEdit", ujetIndividualMemberEdit);

    function ujetIndividualMemberEdit() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/lists/individualMemberEdit/individualMemberEditView.html",
            scope: {
                model: "="
            },
            controller: "ujetIndividualMemberEditDirCtrl"
        };

        return directive;
    };
})();