(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDocumentListDirCtrl", ujetDocumentListDirCtrl);

    ujetDocumentListDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetDocumentFactory"];

    function ujetDocumentListDirCtrl($scope, $controller, queryService, ujetDocumentFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "DocumentId"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            query: query,
            config: {
                objectFactory: ujetDocumentFactory
            }
        });
    };
})();