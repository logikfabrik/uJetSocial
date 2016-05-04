(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetObjectsPicker", ujetObjectsPickerDir);

    /**
     * Directive for picking one or more objects.
     * 
     * @returns {undefined} 
     */
    function ujetObjectsPickerDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/pickers/objectsPicker/objectsPickerView.html",
            scope: {
                model: "=",
                canPickPage: "=",
                canPickComment: "=",
                canPickGroup: "=",
                canPickGuest: "=",
                canPickUser: "=",
                canPickReport: "="
            },
            controller: "ujetObjectsPickerDirCtrl"
        };

        return directive;
    };
})();