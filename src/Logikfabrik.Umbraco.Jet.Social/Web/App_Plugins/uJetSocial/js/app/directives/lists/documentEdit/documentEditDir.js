﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetDocumentEdit", ujetDocumentEdit);

    function ujetDocumentEdit() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/lists/documentEdit/documentEditView.html",
            scope: {
                model: "="
            },
            controller: "ujetDocumentEditDirCtrl"
        };

        return directive;
    };
})();