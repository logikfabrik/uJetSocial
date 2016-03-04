(function () {
    "use strict";

    angular
        .module("umbraco.directives")
        .directive("ujetObject", ujetObjectDir);

    function ujetObjectDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/object/objectView.html",
            scope: {
                obj: "=",
                canSelect: "=",
                canEdit: "=",
                canDelete: "="
            },
            controller: "ujetObjectDirCtrl"
        };

        return directive;
    };
})();