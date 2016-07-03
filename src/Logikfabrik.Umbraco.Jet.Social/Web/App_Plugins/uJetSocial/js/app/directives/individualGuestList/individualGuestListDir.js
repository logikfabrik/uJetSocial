(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetIndividualGuestList", ujetIndividualGuestListDir);

    function ujetIndividualGuestListDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/individualGuestList/individualGuestListView.html",
            scope: true,
            controller: "ujetIndividualGuestListDirCtrl"
        };

        return directive;
    };
})();