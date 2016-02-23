(function () {
    'use strict';

    angular
        .module("umbraco.directives")
        .directive("ujetList", ujetList);

    function ujetList() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/list/listView.html",
            scope: {
                model: "="
            },
            controller: "ujetListDirCtrl"
        };

        return directive;
    };
})();