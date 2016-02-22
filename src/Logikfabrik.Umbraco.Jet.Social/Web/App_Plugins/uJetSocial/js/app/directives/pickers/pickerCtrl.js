(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetPickerCtrl", ujetPickerCtrl);

    function ujetPickerCtrl($scope, objectFactory, queryService, param) {
        var vm = {
            hasObjects: false,
            search: search
        };

        $scope.vm = vm;

        var query = queryService.getQuery();

        query.PageSize.Value = 5;

        function search() {
            var q = {};

            q[param] = vm.query;

            objectFactory.query(query.compile(q)).success(function (data) {
                vm.objects = data.Objects;
                vm.hasObjects = true;

                vm.paging = {
                    PageIndex: query.PageIndex.Value,
                    PageCount: Math.ceil(data.Total / query.PageSize.Value)
                };
            });
        };

        $scope.$on("selectObject", function (e, obj) {
            $scope.dialogOptions.callback(obj);
        });

        $scope.$on("pageIndexChanged", function (e, pageIndex) {
            query.PageIndex.Value = pageIndex;

            search();
        });
    };
})();