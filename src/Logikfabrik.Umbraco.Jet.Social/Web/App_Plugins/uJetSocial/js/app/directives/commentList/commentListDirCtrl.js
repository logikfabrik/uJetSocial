(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentListDirCtrl", ujetCommentListDirCtrl);

    ujetCommentListDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetCommentFactory"];

    function ujetCommentListDirCtrl($scope, $controller, queryService, ujetCommentFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "EntityId", "AuthorId", "Text"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            query: query,
            config: {
                objectFactory: ujetCommentFactory
            }
        });
    };
})();