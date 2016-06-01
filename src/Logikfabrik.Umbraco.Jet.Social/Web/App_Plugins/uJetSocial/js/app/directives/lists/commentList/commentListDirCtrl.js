﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentListDirCtrl", ujetCommentListDirCtrl);

    ujetCommentListDirCtrl.$inject = ["$scope", "$controller", "dialogService", "notificationsService", "queryService", "ujetCommentFactory"];

    function ujetCommentListDirCtrl($scope, $controller, dialogService, notificationsService, queryService, ujetCommentFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "EntityId", "AuthorId", "Text"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            dialogService: dialogService,
            notificationsService: notificationsService,
            query: query,
            config: {
                objectFactory: ujetCommentFactory,
                editTemplate: "/App_Plugins/uJetSocial/backoffice/ujetComment/edit.html",
                editSuccessMessage: "Comment updated",
                editErrorMessage: "Comment could not be updated"
            }
        });
    };
})();