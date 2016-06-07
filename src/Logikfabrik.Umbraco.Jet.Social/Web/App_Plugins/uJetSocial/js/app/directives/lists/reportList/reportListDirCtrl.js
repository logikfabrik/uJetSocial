(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetReportListDirCtrl", ujetReportListDirCtrl);

    ujetReportListDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetReportFactory"];

    function ujetReportListDirCtrl($scope, $controller, queryService, ujetReportFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "EntityId", "AuthorId", "Text"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            query: query,
            config: {
                objectFactory: ujetReportFactory
            }
        });
    };
})();