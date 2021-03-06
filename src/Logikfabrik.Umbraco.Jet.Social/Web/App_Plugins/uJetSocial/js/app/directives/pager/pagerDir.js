﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetPager", ujetPagerDir);

    function ujetPagerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pager/pagerView.html",
            scope: {
                model: "="
            },
            controller: "ujetPagerDirCtrl"
        };

        return directive;
    };
})();