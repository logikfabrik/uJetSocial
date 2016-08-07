(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetPickerCtrl", ujetPickerCtrl);

    function ujetPickerCtrl($scope, notificationsService, localService, queryService, config, callback) {
        var vm = {
            hasObjects: false,
            search: search,
            config: {
                local: localService.localize({
                    errorCategoryGeneral: null,
                    generalError: null,

                    typeToSearch: null
                })
            }
        };

        $scope.vm = vm;

        var query = queryService.getQuery();

        query.pageSize.value = 5;

        function search() {
            var q = {};

            q[config.objectParam] = vm.query;

            config.objectFactory.query(query.compile(q))
                .then(function(response) {
                    vm.objects = response.data.objects;

                    vm.paging = {
                        pageIndex: query.pageIndex.value,
                        pageCount: Math.ceil(response.data.total / query.pageSize.value)
                    };

                    vm.hasObjects = vm.objects.length > 0;
                }, function() {
                    notificationsService.error(vm.config.local.errorCategoryGeneral, vm.config.local.generalError);
                });
        };

        $scope.$on("selectObject", function (e, object) {
            callback(object);
        });

        $scope.$on("pageIndexChanged", function (e, pageIndex) {
            query.pageIndex.value = pageIndex;

            search();
        });

        // Do an initial search, displaying hits as the picker has loaded.
        search();
    };
})();