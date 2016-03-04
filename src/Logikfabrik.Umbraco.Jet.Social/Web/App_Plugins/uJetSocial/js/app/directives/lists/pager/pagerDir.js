(function () {
    "use strict";

    angular
        .module("umbraco.directives")
        .directive("ujetPager", ujetPager);

    function ujetPager() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/lists/pager/pagerView.html",
            scope: {
                model: "="
            },
            controller: "ujetPagerDirCtrl"
        };

        return directive;
    };
})();