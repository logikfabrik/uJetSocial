(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetGroupListDirCtrl", ujetGroupListDirCtrl);

    ujetGroupListDirCtrl.$inject = ["$scope", "$controller", "_", "dialogService", "notificationsService", "queryService", "ujetGroupFactory"];

    function ujetGroupListDirCtrl($scope, $controller, _, dialogService, notificationsService, queryService, ujetGroupFactory) {
        $controller("ujetListCtrl", {
            $scope: $scope,
            _: _,
            dialogService: dialogService,
            notificationsService: notificationsService,
            queryService: queryService,
            config: {
                objectFactory: ujetGroupFactory,
                objectParams: ["Id", "Created", "Updated", "Status", "Name", "Description", "OwnerId"],
                editTemplate: "/App_Plugins/uJetSocial/backoffice/group/edit.html",
                editSuccessMessage: "Group updated",
                editErrorMessage: "Group could not be updated"
            }
        });
    };
})();