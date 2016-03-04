(function () {
    "use strict";

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

        query.pageSize.value = 5;

        function search() {
            var q = {};

            q[param] = vm.query;

            objectFactory.query(query.compile(q)).success(function (data) {
                vm.objects = data.objects;

                vm.paging = {
                    pageIndex: query.pageIndex.value,
                    pageCount: Math.ceil(data.total / query.pageSize.value)
                };

                vm.hasObjects = true;
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