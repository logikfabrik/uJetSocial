(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetObjectCreateCtrl", ujetObjectCreateCtrl);

    function ujetObjectCreateCtrl($scope, $location, notificationsService, localService, config) {
        var vm = {
            object: {},
            create: create,
            cancel: cancel,
            config: {
                local: localService.localize(config.local)
            }
        };

        $scope.vm = vm;

        function create(form) {
            if (!form.$valid) {
                return;
            }

            config.objectFactory.add(vm.object)
                .then(function() {
                    notificationsService.success(vm.config.local.successCategory, vm.config.local.success);

                    $location.path(config.path);

                    close();
                }, function() {
                    notificationsService.error(vm.config.local.errorCategory, vm.config.local.error);
                });
        };

        function cancel() {
            close();
        };

        function close() {
            /*
             * We cannot use the dialog service, as it doesn't allow the dialog to be closed gracefully.
             * As a hack we emit an internal event that Umbraco handles.
            */
            $scope.$emit("app.closeDialogs", undefined);
        };
    };
})();