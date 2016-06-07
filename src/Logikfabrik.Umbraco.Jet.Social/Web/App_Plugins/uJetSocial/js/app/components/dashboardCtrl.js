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
            console.log("Save changes");

            updateObject(object);
        });

        $scope.$on("cancelEdit", function () {
            console.log("Cancel changes");
        });

        $scope.$on("selectedRowChanged", function (e, row) {
            vm.object = row;
        });

        function updateObject(object) {
            config.objectFactory.update(object)
                .success(function() {
                    notificationsService.success(config.successMessage);
                })
                .error(function() {
                    notificationsService.error(config.errorMessage);
                });
        }
    };
})();