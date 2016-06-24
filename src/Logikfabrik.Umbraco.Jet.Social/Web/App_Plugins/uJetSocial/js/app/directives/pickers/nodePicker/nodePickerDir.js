(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetNodePicker", ujetNodePickerDir);

    /**
     * Directive for picking one object.
     * 
     * @returns {} 
     */
    function ujetNodePickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/nodePicker/nodePickerView.html",
            scope: {
                model: "=",
                canPickDocument: "=",
                canPickMedia: "=",
                canPickMember: "="
            },
            controller: "ujetNodePickerDirCtrl"
        };

        return directive;
    };
})();