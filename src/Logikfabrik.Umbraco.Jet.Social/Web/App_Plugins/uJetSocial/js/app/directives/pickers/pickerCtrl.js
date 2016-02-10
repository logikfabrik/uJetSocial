(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetPickerCtrl", ujetPickerCtrl);

    function ujetPickerCtrl($scope, objectFactory, queryService) {
        var vm = {
            hasObjects: false,
            search: search
        };

        $scope.vm = vm;

        function search(params) {
            var q = queryService.getQuery().compile(params);

            objectFactory.query(q).success(function (data) {
                vm.hasObjects = true;
                vm.objects = data.Objects;
            });
        };

        $scope.$on("selectObject", function (e, obj) {
            $scope.dialogOptions.callback(obj);
        });
    };
})();