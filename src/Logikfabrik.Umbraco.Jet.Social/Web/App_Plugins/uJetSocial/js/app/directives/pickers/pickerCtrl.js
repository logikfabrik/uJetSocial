(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetPickerCtrl", ujetPickerCtrl);

    function ujetPickerCtrl($scope, queryService, config) {
        var vm = {
            hasObjects: false,
            search: search
        };

        $scope.vm = vm;

        var query = queryService.getQuery();

        query.pageSize.value = 5;

        function search() {
            var q = {};

            q[config.objectParam] = vm.query;

            config.objectFactory.query(query.compile(q)).success(function (data) {
                vm.objects = data.objects;

                vm.paging = {
                    pageIndex: query.pageIndex.value,
                    pageCount: Math.ceil(data.total / query.pageSize.value)
                };

                vm.hasObjects = vm.objects.length > 0;
            });
        };

        $scope.$on("selectObject", function (e, obj) {
            $scope.dialogOptions.callback(obj);
        });

        $scope.$on("pageIndexChanged", function (e, pageIndex) {
            query.pageIndex.value = pageIndex;

            search();
        });
    };
})();