(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentListDirCtrl", ujetCommentListDirCtrl);

    ujetCommentListDirCtrl.$inject = ["$scope", "$controller", "notificationsService", "localService", "queryService", "ujetCommentFactory"];

    function ujetCommentListDirCtrl($scope, $controller, notificationsService, localService, queryService, ujetCommentFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "EntityId", "AuthorId", "Text"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            query: query,
            config: {
                objectFactory: ujetCommentFactory
            }
        });
    };
})();