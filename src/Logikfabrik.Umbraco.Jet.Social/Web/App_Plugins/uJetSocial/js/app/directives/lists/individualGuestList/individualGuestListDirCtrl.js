(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualGuestListDirCtrl", ujetIndividualGuestListDirCtrl);

    ujetIndividualGuestListDirCtrl.$inject = ["$scope", "$controller", "$routeParams", "dialogService", "notificationsService", "queryService", "ujetIndividualGuestFactory"];

    function ujetIndividualGuestListDirCtrl($scope, $controller, $routeParams, dialogService, notificationsService, queryService, ujetIndividualGuestFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "FirstName", "LastName"]);

        var config = {
            objectFactory: ujetIndividualGuestFactory,
            editTemplate: "/App_Plugins/uJetSocial/backoffice/individualGuest/edit.html",
            editSuccessMessage: "Guest updated",
            editErrorMessage: "Guest could not be updated"
        };

        if (isNaN(parseInt($routeParams.id, 10))) {
            config.searchParams = { firstName: $routeParams.id }
        }

        $controller("ujetListCtrl", {
            $scope: $scope,
            dialogService: dialogService,
            notificationsService: notificationsService,
            query: query,
            config: config
        });
    };
})();