(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportListDirCtrl", ujetReportListDirCtrl);

    ujetReportListDirCtrl.$inject = ["$scope", "$controller", "notificationsService", "localService", "queryService", "ujetReportFactory"];

    function ujetReportListDirCtrl($scope, $controller, notificationsService, localService, queryService, ujetReportFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "EntityId", "AuthorId", "Text"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            query: query,
            config: {
                objectFactory: ujetReportFactory
            }
        });
    };
})();