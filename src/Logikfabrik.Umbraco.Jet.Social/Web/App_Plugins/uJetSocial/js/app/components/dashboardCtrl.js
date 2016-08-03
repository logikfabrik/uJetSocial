(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDashboardCtrl", ujetDashboardCtrl);

    function ujetDashboardCtrl($scope, notificationsService, config) {
        var vm = {};

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
                    notificationsService.success(config.successMessage);
                }, function() {
                    notificationsService.error(config.errorMessage);
                });
        }
    };
})();