(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetCommentList", ujetCommentListDir);

    function ujetCommentListDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/commentList/commentListView.html",
            scope: true,
            controller: "ujetCommentListDirCtrl"
        };

        return directive;
    };
})();