(function () {
    "use strict";

    angular
        .module("umbraco.directives")
        .directive("ujetGuestList", ujetGuestList);

    function ujetGuestList() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/lists/guestList/guestListView.html",
            scope: true,
            controller: "ujetGuestListDirCtrl"
        };

        return directive;
    };
})();