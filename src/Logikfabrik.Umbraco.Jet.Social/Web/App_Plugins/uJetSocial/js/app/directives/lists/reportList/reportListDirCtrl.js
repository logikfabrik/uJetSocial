(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetReportListDirCtrl", ujetReportListDirCtrl);

    ujetReportListDirCtrl.$inject = ["$scope", "$controller", "_", "dialogService", "notificationsService", "queryService", "ujetReportFactory"];

    function ujetReportListDirCtrl($scope, $controller, _, dialogService, notificationsService, queryService, ujetReportFactory) {
        $controller("ujetListCtrl", {
            $scope: $scope,
            _: _,
            dialogService: dialogService,
            notificationsService: notificationsService,
            queryService: queryService,
            config: {
                objectFactory: ujetReportFactory,
                objectParams: ["Id", "Created", "Updated", "Status", "EntityId", "AuthorId", "Text"],
                editTemplate: "/App_Plugins/uJetSocial/backoffice/report/edit.html",
                editSuccessMessage: "Report updated",
                editErrorMessage: "Report could not be updated"
            }
        });
    };
})();