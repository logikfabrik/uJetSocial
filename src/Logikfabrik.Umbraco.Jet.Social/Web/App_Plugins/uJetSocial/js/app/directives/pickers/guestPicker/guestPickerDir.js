(function () {
    'use strict';

    angular
        .module("umbraco.directives")
        .directive("ujetGuestPicker", ujetGuestPickerDir);

    function ujetGuestPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/guestPicker/guestPickerView.html",
            scope: true,
            controller: "ujetGuestPickerDirCtrl"
        };

        return directive;
    };
})();