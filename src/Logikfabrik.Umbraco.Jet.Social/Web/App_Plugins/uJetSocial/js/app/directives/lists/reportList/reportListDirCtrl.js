(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportListDirCtrl", ujetReportListDirCtrl);

    ujetReportListDirCtrl.$inject = ["$scope", "$controller", "dialogService", "notificationsService", "queryService", "ujetReportFactory"];

    function ujetReportListDirCtrl($scope, $controller, dialogService, notificationsService, queryService, ujetReportFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "EntityId", "AuthorId", "Text"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            dialogService: dialogService,
            notificationsService: notificationsService,
            query: query,
            config: {
                objectFactory: ujetReportFactory,
                editTemplate: "/App_Plugins/uJetSocial/backoffice/report/edit.html",
                editSuccessMessage: "Report updated",
                editErrorMessage: "Report could not be updated"
            }
        });
    };
})();