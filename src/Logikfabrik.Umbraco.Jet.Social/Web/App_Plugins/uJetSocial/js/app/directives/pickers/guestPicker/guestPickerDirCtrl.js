(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetGuestPickerDirCtrl", ujetGuestPickerDirCtrl);

    ujetGuestPickerDirCtrl.$inject = ["$scope", "_", "ujetGuestFactory", "queryService"];

    function ujetGuestPickerDirCtrl($scope, _, ujetGuestFactory, queryService) {
        var vm = {
            guests: null,
            search: search
        }

        $scope.vm = vm;
        $scope._ = _;

        function search() {
            var q = queryService.getQuery().compile({ "FirstName": vm.query });

            ujetGuestFactory.query(q).success(function (data) {
                vm.guests = data.Objects;
            });
        };

        $scope.$on("selectObject", function (e, obj) {
            $scope.dialogOptions.callback(obj);
        });
    };
})();