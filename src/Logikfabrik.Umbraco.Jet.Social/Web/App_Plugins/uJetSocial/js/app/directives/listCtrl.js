(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetListCtrl", ujetListCtrl);

    function ujetListCtrl($scope, query, config) {
        var vm = {
            hasObjects: false
        };

        $scope.vm = vm;

        function search() {
            config.objectFactory.query(query.compile(config.searchParams)).success(function (data) {
                vm.objects =
                {
                    columns: query.orderBy.options,
                    rows: data.objects
                };

                vm.paging = {
                    pageIndex: query.pageIndex.value,
                    pageCount: Math.ceil(data.total / query.pageSize.value)
                };

                vm.hasObjects = true;
            });
        };

        $scope.$on("pageIndexChanged", function (e, pageIndex) {
            query.pageIndex.value = pageIndex;

            search();
        });

        search();
    };
})();