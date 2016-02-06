(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetGroupListController", ujetGroupListController);

    ujetGroupListController.$inject = ["$routeParams", "navigationService"];

    function ujetGroupListController($routeParams, navigationService) {
        var vm = this;

        vm.params = {
            "Name": $routeParams.id
        };

        navigationService.syncTree({ tree: "group", path: ["-1", $routeParams.id], forceReload: false });
    };
})();