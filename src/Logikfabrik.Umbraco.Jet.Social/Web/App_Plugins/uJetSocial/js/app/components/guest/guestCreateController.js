(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetGuestCreateController", ujetGuestCreateController);

    ujetGuestCreateController.$inject = ["$scope", "$location", "notificationsService", "ujetGuestFactory"];

    function ujetGuestCreateController($scope, $location, notificationsService, ujetGuestFactory) {
        var vm = this;

        vm.guest = {};
        vm.create = create;
        vm.cancel = cancel;

        function create(form) {
            if (!form.$valid) {
                return;
            }

            ujetGuestFactory.add(vm.guest)
                .success(function (id) {
                    notificationsService.success("Guest created");

                    $location.path("/uJetSocial/guest/dashboard/-1");

                    close();
                })
                .error(function () {
                    notificationsService.error("Guest could not be created");
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