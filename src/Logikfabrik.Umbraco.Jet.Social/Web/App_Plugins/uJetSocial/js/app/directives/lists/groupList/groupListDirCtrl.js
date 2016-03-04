(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetGroupListDirCtrl", ujetGroupListDirCtrl);

    ujetGroupListDirCtrl.$inject = ["$scope", "$controller", "$routeParams", "dialogService", "notificationsService", "queryService", "ujetGroupFactory"];

    function ujetGroupListDirCtrl($scope, $controller, $routeParams, dialogService, notificationsService, queryService, ujetGroupFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "Name", "Description", "OwnerId"]);

        var config = {
            objectFactory: ujetGroupFactory,
            editTemplate: "/App_Plugins/uJetSocial/backoffice/group/edit.html",
            editSuccessMessage: "Group updated",
            editErrorMessage: "Group could not be updated"
        };
        
        if (isNaN(parseInt($routeParams.id, 10))) {
            config.searchParams = { name: $routeParams.id }
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