(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDocumentListDirCtrl", ujetDocumentListDirCtrl);

    ujetDocumentListDirCtrl.$inject = ["$scope", "$controller", "notificationsService", "localService", "queryService", "ujetDocumentFactory"];

    function ujetDocumentListDirCtrl($scope, $controller, notificationsService, localService, queryService, ujetDocumentFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "DocumentId"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            query: query,
            config: {
                objectFactory: ujetDocumentFactory
            }
        });
    };
})();