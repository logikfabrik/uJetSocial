(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetLabel", ujetLabelDir);

    function ujetLabelDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/label/labelView.html",
            scope: {
                title: "@",
                description: "@"
            },
            controller: "ujetLabelDirCtrl"
        };

        return directive;
    };
})();