(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetGroupEdit", ujetGroupEditDir);

    function ujetGroupEditDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/groupEdit/groupEditView.html",
            scope: {
                model: "="
            },
            controller: "ujetGroupEditDirCtrl"
        };

        return directive;
    };
})();