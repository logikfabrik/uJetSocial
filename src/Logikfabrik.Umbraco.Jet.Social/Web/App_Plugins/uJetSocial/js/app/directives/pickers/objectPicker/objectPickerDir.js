(function () {
    'use strict';

    angular
        .module("umbraco.directives")
        .directive("ujetObjectPicker", ujetObjectPickerDir);

    function ujetObjectPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/objectPicker/objectPickerView.html",
            scope: {
                model: "=",
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