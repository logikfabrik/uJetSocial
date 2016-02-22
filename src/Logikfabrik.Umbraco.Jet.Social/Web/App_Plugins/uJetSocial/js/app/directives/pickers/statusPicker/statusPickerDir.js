(function () {
    'use strict';

    angular
        .module("umbraco.directives")
        .directive("ujetStatusPicker", ujetStatusPicker);

    function ujetStatusPicker(_) {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/statusPicker/statusPickerView.html",
            scope: {
                model: "="
            },
            controller: "ujetStatusPickerDirCtrl"
        };

        return directive;
    };
})();