(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetObjectPicker", ujetObjectPickerDir);

    /**
     * Directive for picking one object.
     * 
     * @returns {} 
     */
    function ujetObjectPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/objectPicker/objectPickerView.html",
            scope: {
                model: "=",
                canPickComment: "=",
                canPickDocument: "=",
                canPickGroup: "=",
                canPickGuest: "=",
                canPickMedia: "=",
                canPickMember: "=",
                canPickReport: "="
            },
            controller: "ujetObjectPickerDirCtrl"
        };

        return directive;
    };
})();