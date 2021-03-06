﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetCommentEdit", ujetCommentEditDir);

    function ujetCommentEditDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/commentEdit/commentEditView.html",
            scope: {
                model: "="
            },
            controller: "ujetCommentEditDirCtrl"
        };

        return directive;
    };
})();