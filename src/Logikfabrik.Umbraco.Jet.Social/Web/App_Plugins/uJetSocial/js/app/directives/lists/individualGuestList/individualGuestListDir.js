(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetIndividualGuestList", ujetIndividualGuestList);

    function ujetIndividualGuestList() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/lists/individualGuestList/individualGuestListView.html",
            scope: true,
            controller: "ujetIndividualGuestListDirCtrl"
        };

        return directive;
    };
})();