(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetGuestListCtrl", ujetGuestListCtrl);

    ujetGuestListCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetGuestListCtrl($routeParams, navigationService) {
        var vm = this;

        vm.params = {
            "FirstName": $routeParams.id
        };
        
        navigationService.syncTree({ tree: "guest", path: ["-1", $routeParams.id], forceReload: false });
    };
})();