(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetReportCreateCtrl", ujetReportCreateCtrl);

    ujetReportCreateCtrl.$inject = ["$scope", "$location", "notificationsService", "ujetReportFactory"];

    function ujetReportCreateCtrl($scope, $location, notificationsService, ujetReportFactory) {
        var vm = this;

        vm.report = {};
        vm.create = create;
        vm.cancel = cancel;

        function create(form) {
            if (!form.$valid) {
                return;
            }

            ujetReportFactory.add(vm.report)
                .success(function (id) {
                    notificationsService.success("Report created");

                    $location.path("/uJetSocial/report/dashboard/-1");

                    close();
                })
                .error(function () {
                    notificationsService.error("Report could not be created");
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