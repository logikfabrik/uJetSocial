(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetStatusPickerDirCtrl", ujetStatusPickerDirCtrl);

    ujetStatusPickerDirCtrl.$inject = ["$scope"];

    function ujetStatusPickerDirCtrl($scope) {
        var vm = {
            status: $scope.model
        }

        $scope.vm = vm;

        $scope.$watch("vm.status", function (newValue, oldValue) {
            $scope.model = newValue;
        });
    };
})();