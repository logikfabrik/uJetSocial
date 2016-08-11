(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetSpinner", ujetSpinnerDir);

    function ujetSpinnerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/spinner/spinnerView.html",
            scope: true,
            controller: "ujetSpinnerDirCtrl"
        };

        return directive;
    };
})();