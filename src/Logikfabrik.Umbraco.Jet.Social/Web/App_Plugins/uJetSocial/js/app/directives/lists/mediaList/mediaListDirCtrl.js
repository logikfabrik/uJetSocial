(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMediaListDirCtrl", ujetMediaListDirCtrl);

    ujetMediaListDirCtrl.$inject = ["$scope", "$controller", "dialogService", "notificationsService", "queryService", "ujetMediaFactory"];

    function ujetMediaListDirCtrl($scope, $controller, dialogService, notificationsService, queryService, ujetMediaFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "MediaId"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            dialogService: dialogService,
            notificationsService: notificationsService,
            query: query,
            config: {
                objectFactory: ujetMediaFactory,
                editTemplate: "/App_Plugins/uJetSocial/backoffice/ujetMedia/edit.html",
                editSuccessMessage: "Media updated",
                editErrorMessage: "Media could not be updated"
            }
        });
    };
})();