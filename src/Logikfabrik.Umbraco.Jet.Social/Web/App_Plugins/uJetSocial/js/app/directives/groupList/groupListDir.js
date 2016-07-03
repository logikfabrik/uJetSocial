(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetGroupList", ujetGroupList);

    function ujetGroupList() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/groupList/groupListView.html",
            scope: true,
            controller: "ujetGroupListDirCtrl"
        };

        return directive;
    };
})();