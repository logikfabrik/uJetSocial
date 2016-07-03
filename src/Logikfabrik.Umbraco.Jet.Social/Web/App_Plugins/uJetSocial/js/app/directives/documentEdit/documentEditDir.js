(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetDocumentEdit", ujetDocumentEditDir);

    function ujetDocumentEditDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/documentEdit/documentEditView.html",
            scope: {
                model: "="
            },
            controller: "ujetDocumentEditDirCtrl"
        };

        return directive;
    };
})();