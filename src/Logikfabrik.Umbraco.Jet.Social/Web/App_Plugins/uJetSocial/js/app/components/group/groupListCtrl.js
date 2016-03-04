(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetGroupListCtrl", ujetGroupListCtrl);

    ujetGroupListCtrl.$inject = ["$routeParams", "navigationService"];

    function ujetGroupListCtrl($routeParams, navigationService) {
        var vm = this;

        vm.params = {
            "Name": $routeParams.id
        };

        navigationService.syncTree({ tree: "group", path: ["-1", $routeParams.id], forceReload: false });
    };
})();