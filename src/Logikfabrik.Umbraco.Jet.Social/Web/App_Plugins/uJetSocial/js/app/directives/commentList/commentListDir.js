(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetCommentList", ujetCommentList);

    function ujetCommentList() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/commentList/commentListView.html",
            scope: true,
            controller: "ujetCommentListDirCtrl"
        };

        return directive;
    };
})();