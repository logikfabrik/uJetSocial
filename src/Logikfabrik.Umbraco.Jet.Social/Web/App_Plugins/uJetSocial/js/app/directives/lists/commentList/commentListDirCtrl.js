(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetCommentListDirCtrl", ujetCommentListDirCtrl);

    ujetCommentListDirCtrl.$inject = ["$scope", "$controller", "_", "dialogService", "notificationsService", "queryService", "ujetCommentFactory"];

    function ujetCommentListDirCtrl($scope, $controller, _, dialogService, notificationsService, queryService, ujetCommentFactory) {
        $controller("ujetListCtrl", {
            $scope: $scope,
            _: _,
            dialogService: dialogService,
            notificationsService: notificationsService,
            queryService: queryService,
            config: {
                objectFactory: ujetCommentFactory,
                objectParams: ["Id", "Created", "Updated", "Status", "EntityId", "AuthorId", "Text"],
                editTemplate: "/App_Plugins/uJetSocial/backoffice/comment/edit.html",
                editSuccessMessage: "Comment updated",
                editErrorMessage: "Comment could not be updated"
            }
        });
    };
})();