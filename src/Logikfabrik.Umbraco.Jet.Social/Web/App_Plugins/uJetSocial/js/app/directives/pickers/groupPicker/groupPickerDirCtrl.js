(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetGroupPickerDirCtrl", ujetGroupPickerDirCtrl);

    ujetGroupPickerDirCtrl.$inject = ["$scope", "_", "ujetGroupFactory", "queryService"];

    function ujetGroupPickerDirCtrl($scope, _, ujetGroupFactory, queryService) {
        var vm = {
            groups: null,
            search: search
        }

        $scope.vm = vm;
        $scope._ = _;

        function search() {
            var q = queryService.getQuery().compile({ "Name": vm.query });

            ujetGroupFactory.query(q).success(function (data) {
                vm.groups = data.Objects;
            });
        };

        $scope.$on("selectObject", function (e, obj) {
            $scope.dialogOptions.callback(obj);
        });
    };
})();