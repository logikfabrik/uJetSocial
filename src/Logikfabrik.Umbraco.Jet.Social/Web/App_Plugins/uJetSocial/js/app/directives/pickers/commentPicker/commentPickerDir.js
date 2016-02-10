(function () {
    'use strict';

    angular
        .module("umbraco.directives")
        .directive("ujetCommentPicker", ujetCommentPickerDir);

    function ujetCommentPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/commentPicker/commentPickerView.html",
            scope: true,
            controller: "ujetCommentPickerDirCtrl"
        };

        return directive;
    };
})();