(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetGuestListController", ujetGuestListController);

    ujetGuestListController.$inject = ["$routeParams", "navigationService"];

    function ujetGuestListController($routeParams, navigationService) {
        var vm = this;

        vm.params = {
            "FirstName": $routeParams.id
        };
        
        navigationService.syncTree({ tree: "guest", path: ["-1", $routeParams.id], forceReload: false });
    };
})();