(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualMemberListDirCtrl", ujetIndividualMemberListDirCtrl);

    ujetIndividualMemberListDirCtrl.$inject = ["$scope", "$controller", "dialogService", "notificationsService", "queryService", "ujetIndividualMemberFactory"];

    function ujetIndividualMemberListDirCtrl($scope, $controller, dialogService, notificationsService, queryService, ujetIndividualMemberFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "MemberId"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            dialogService: dialogService,
            notificationsService: notificationsService,
            query: query,
            config: {
                objectFactory: ujetIndividualMemberFactory,
                editTemplate: "/App_Plugins/uJetSocial/backoffice/ujetIndividualMember/edit.html",
                editSuccessMessage: "Member updated",
                editErrorMessage: "Member could not be updated"
            }
        });
    };
})();