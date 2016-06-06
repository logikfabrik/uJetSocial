(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDocumentListDirCtrl", ujetDocumentListDirCtrl);

    ujetDocumentListDirCtrl.$inject = ["$scope", "$controller", "dialogService", "notificationsService", "queryService", "ujetDocumentFactory"];

    function ujetDocumentListDirCtrl($scope, $controller, dialogService, notificationsService, queryService, ujetDocumentFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "DocumentId"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            dialogService: dialogService,
            notificationsService: notificationsService,
            query: query,
            config: {
                objectFactory: ujetDocumentFactory,
                editTemplate: "/App_Plugins/uJetSocial/backoffice/ujetDocument/edit.html",
                editSuccessMessage: "Document updated",
                editErrorMessage: "Document could not be updated"
            }
        });
    };
})();