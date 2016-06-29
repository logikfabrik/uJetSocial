(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetPickerCtrl", ujetPickerCtrl);

    function ujetPickerCtrl($scope, localizationService, queryService, config, callback) {
        var vm = {
            hasObjects: false,
            search: search
        };

        localizationService.localize("uJetSocial_typeToSearch")
            .then(function(value) {
                vm.placeholder = value;
            });

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