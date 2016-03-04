(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetGuestListDirCtrl", ujetGuestListDirCtrl);

    ujetGuestListDirCtrl.$inject = ["$scope", "$controller", "_", "dialogService", "notificationsService", "queryService", "ujetGuestFactory"];

    function ujetGuestListDirCtrl($scope, $controller, _, dialogService, notificationsService, queryService, ujetGuestFactory) {
        $controller("ujetListCtrl", {
            $scope: $scope,
            _: _,
            dialogService: dialogService,
            notificationsService: notificationsService,
            queryService: queryService,
            config: {
                objectFactory: ujetGuestFactory,
                objectParams: ["Id", "Created", "Updated", "Status", "FirstName", "LastName"],
                editTemplate: "/App_Plugins/uJetSocial/backoffice/guest/edit.html",
                editSuccessMessage: "Guest updated",
                editErrorMessage: "Guest could not be updated"
            }
        });
    };
})();