(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetMediaEdit", ujetMediaEditDir);

    function ujetMediaEditDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/mediaEdit/mediaEditView.html",
            scope: {
                model: "="
            },
            controller: "ujetMediaEditDirCtrl"
        };

        return directive;
    };
})();