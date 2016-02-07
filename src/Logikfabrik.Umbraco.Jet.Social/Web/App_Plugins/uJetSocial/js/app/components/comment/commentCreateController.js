(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetCommentCreateController", ujetCommentCreateController);

    ujetCommentCreateController.$inject = ["$scope", "$location", "notificationsService", "ujetCommentFactory"];

    function ujetCommentCreateController($scope, $location, notificationsService, ujetCommentFactory) {
        var vm = this;

        vm.comment = {};
        vm.create = create;
        vm.cancel = cancel;

        function create(form) {
            if (!form.$valid) {
                return;
            }

            ujetCommentFactory.add(vm.comment)
                .success(function (id) {
                    notificationsService.success("Comment created");

                    $location.path("/uJetSocial/comment/dashboard/-1");

                    close();
                })
                .error(function () {
                    notificationsService.error("Comment could not be created");
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