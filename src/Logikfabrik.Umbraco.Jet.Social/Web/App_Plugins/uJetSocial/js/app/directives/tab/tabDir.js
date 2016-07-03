(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetTab", ujetTabDir);

    function ujetTabDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/tab/tabView.html",
            scope: {
                header: "@"
            },
            controller: "ujetTabDirCtrl",
            transclude: true
        };

        return directive;
    };
})();