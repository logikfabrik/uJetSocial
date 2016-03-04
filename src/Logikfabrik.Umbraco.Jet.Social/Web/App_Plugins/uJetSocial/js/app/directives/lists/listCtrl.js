(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetListCtrl", ujetListCtrl);

    function ujetListCtrl($scope, _, dialogService, notificationsService, queryService, config) {
        var vm = {
            hasObjects: false
        };

        $scope.vm = vm;

        var dialog;
        var query = queryService.getQuery(config.objectParams);

        function search() {
            config.objectFactory.query(query.compile(config.objectParams)).success(function (data) {
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

        function updateObj(obj) {
            if (!_.isNull(dialog)) {
                dialogService.close(dialog);
            }

            config.objectFactory.update(obj)
                .success(function () {
                    notificationsService.success(config.editSuccessMessage);

                    search();
                })
                .error(function () {
                    notificationsService.error(config.editErrorMessage);
                });

            dialog = null;
        }

        $scope.$on("pageIndexChanged", function (e, pageIndex) {
            query.pageIndex.value = pageIndex;

            search();
        });

        $scope.$on("selectedRowChanged", function (e, row) {
            if (!_.isNull(dialog)) {
                dialogService.close(dialog);
            }

            dialog = dialogService.open({
                template: config.editTemplate,
                callback: updateObj,
                dialogData: row
            });
        });

        search();
    };
})();