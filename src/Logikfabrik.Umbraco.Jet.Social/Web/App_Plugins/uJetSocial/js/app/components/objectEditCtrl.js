(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetObjectEditCtrl", ujetObjectEditCtrl);

    ujetObjectEditCtrl.$inject = ["$scope", "_"];

    function ujetObjectEditCtrl($scope, _) {
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