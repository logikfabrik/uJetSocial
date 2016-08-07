(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetObjectCreateCtrl", ujetObjectCreateCtrl);

    function ujetObjectCreateCtrl($scope, $location, notificationsService, config) {
        var vm = {
            object: {},
            create: create,
            cancel: cancel
        };

        $scope.vm = vm;

        function create(form) {
            if (!form.$valid) {
                return;
            }

            config.objectFactory.add(vm.object)
                .then(function() {
                    notificationsService.success(config.createSuccessMessage);

                    $location.path(config.path);

                    close();
                }, function() {
                    notificationsService.error(config.createErrorMessage);
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