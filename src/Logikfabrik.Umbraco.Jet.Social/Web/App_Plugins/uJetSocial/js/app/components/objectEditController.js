(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetObjectEditController", ujetObjectEditController);

    ujetObjectEditController.$inject = ["$scope", "_"];

    function ujetObjectEditController($scope, _) {
        var vm = this;

        vm.object = _.clone($scope.dialogData);
        vm.save = save;

        function save(form) {
            if (!form.$valid) {
                return;
            }

            $scope.dialogOptions.callback(vm.object);
        };
    };
})();