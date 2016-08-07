(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDashboardCtrl", ujetDashboardCtrl);

    function ujetDashboardCtrl($scope, notificationsService, localService, config) {
        var vm = {
            config: {
                local: localService.localize(config.local)
            }
        };

        $scope.vm = vm;

        $scope.$on("saveEdit", function (e, object) {
            updateObject(object);
        });

        $scope.$on("cancelEdit", function () {
            vm.object = null;
        });

        $scope.$on("selectedRowChanged", function (e, row) {
            vm.object = row;
        });

        function updateObject(object) {
            config.objectFactory.update(object)
                .then(function() {
                    notificationsService.success(vm.config.local.successCategory, vm.config.local.success);
                }, function() {
                    notificationsService.error(vm.config.local.errorCategory, vm.config.local.error);
                });
        }
    };
})();