(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetIndividualGuestEdit", ujetIndividualGuestEdit);

    function ujetIndividualGuestEdit() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/individualGuestEdit/individualGuestEditView.html",
            scope: {
                model: "="
            },
            controller: "ujetIndividualGuestEditDirCtrl"
        };

        return directive;
    };
})();