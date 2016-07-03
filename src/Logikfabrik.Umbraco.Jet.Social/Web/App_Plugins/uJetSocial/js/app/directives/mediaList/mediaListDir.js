(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetMediaList", ujetMediaListDir);

    function ujetMediaListDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/mediaList/mediaListView.html",
            scope: true,
            controller: "ujetMediaListDirCtrl"
        };

        return directive;
    };
})();