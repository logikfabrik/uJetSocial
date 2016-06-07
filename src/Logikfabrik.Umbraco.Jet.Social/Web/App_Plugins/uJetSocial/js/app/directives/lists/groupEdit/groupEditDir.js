(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetGroupEdit", ujetGroupEdit);

    function ujetGroupEdit() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/lists/groupEdit/groupEditView.html",
            scope: {
                model: "="
            },
            controller: "ujetGroupEditDirCtrl"
        };

        return directive;
    };
})();