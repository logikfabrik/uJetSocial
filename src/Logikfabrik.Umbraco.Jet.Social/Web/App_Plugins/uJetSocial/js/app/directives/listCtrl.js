(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetListCtrl", ujetListCtrl);

    function ujetListCtrl($scope, notificationsService, localService, query, config) {
        var vm = {
            hasObjects: false,
            config: {
                local: localService.localize({
                    errorCategoryGeneral: "",
                    generalError: ""
                })
            }
        };

        $scope.vm = vm;

        function search() {
            config.objectFactory.query(query.compile(config.searchParams))
                .then(function(response) {
                    vm.objects = {
                        columns: query.orderBy.options,
                        rows: response.data.objects
                    };

                    vm.paging = {
                        pageIndex: query.pageIndex.value,
                        pageCount: Math.ceil(response.data.total / query.pageSize.value)
                    };

                    vm.hasObjects = true;
                }, function() {
                    notificationsService.error(vm.config.local.errorCategoryGeneral, vm.config.local.generalError);
                });
        };

        $scope.$on("pageIndexChanged", function (e, pageIndex) {
            query.pageIndex.value = pageIndex;

            search();
        });

        search();
    };
})();