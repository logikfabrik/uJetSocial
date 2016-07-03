(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetTabs", ujetTabsDir);

    function ujetTabsDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/tabs/tabsView.html",
            scope: true,
            controller: "ujetTabsDirCtrl",
            transclude: true
        };

        return directive;
    };
})();