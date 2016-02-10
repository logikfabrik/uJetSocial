(function () {
    'use strict';

    angular
        .module("umbraco.directives")
        .directive("ujetGroupPicker", ujetGroupPicker);

    function ujetGroupPicker() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/groupPicker/groupPickerView.html",
            scope: true,
            controller: "ujetGroupPickerDirCtrl"
        };

        return directive;
    };
})();