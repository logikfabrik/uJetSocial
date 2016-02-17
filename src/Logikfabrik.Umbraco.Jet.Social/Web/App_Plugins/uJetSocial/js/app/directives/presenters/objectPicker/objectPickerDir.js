(function () {
    'use strict';

    angular
        .module("umbraco.directives")
        .directive("ujetObjectPicker", ujetObjectPickerDir);

    function ujetObjectPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/objectPicker/objectPickerView.html",
            scope: {
                obj: "=",
                canPickPage: "=",
                canPickComment: "=",
                canPickGroup: "=",
                canPickGuest: "=",
                canPickUser: "=",
                canPickReport: "="
            },
            controller: "ujetObjectPickerDirCtrl"
        };

        return directive;
    };
})();