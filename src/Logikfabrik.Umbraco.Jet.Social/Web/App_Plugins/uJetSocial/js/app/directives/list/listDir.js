(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetList", ujetListDir);

    function ujetListDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/list/listView.html",
            scope: {
                model: "="
            },
            controller: "ujetListDirCtrl"
        };

        return directive;
    };
})();