﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetDocumentList", ujetDocumentListDir);

    function ujetDocumentListDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/documentList/documentListView.html",
            scope: true,
            controller: "ujetDocumentListDirCtrl"
        };

        return directive;
    };
})();