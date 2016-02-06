﻿(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetGroupCreateController", ujetGroupCreateController);

    ujetGroupCreateController.$inject = ["$scope", "$location", "notificationsService", "groupFactory"];

    function ujetGroupCreateController($scope, $location, notificationsService, groupFactory) {
        var vm = this;

        vm.group = {};
        vm.create = create;
        vm.cancel = cancel;

        function create(form) {
            if (!form.$valid) {
                return;
            }

            groupFactory.add(vm.group)
                .success(function (id) {
                    notificationsService.success("Group created");

                    $location.path("/uJetSocial/group/dashboard/-1");

                    close();
                })
                .error(function () {
                    notificationsService.error("Group could not be created");
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