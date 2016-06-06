(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetMediaList", ujetMediaList);

    function ujetMediaList() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/lists/mediaList/mediaListView.html",
            scope: true,
            controller: "ujetMediaListDirCtrl"
        };

        return directive;
    };
})();