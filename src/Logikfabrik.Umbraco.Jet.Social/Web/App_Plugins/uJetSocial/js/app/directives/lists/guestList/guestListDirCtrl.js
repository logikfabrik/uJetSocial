(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetGuestListDirCtrl", ujetGuestListDirCtrl);

    ujetGuestListDirCtrl.$inject = ["$scope", "$controller", "$routeParams", "dialogService", "notificationsService", "queryService", "ujetGuestFactory"];

    function ujetGuestListDirCtrl($scope, $controller, $routeParams, dialogService, notificationsService, queryService, ujetGuestFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "FirstName", "LastName"]);

        var config = {
            objectFactory: ujetGuestFactory,
            editTemplate: "/App_Plugins/uJetSocial/backoffice/guest/edit.html",
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