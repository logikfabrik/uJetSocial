(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMediaListDirCtrl", ujetMediaListDirCtrl);

    ujetMediaListDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetMediaFactory"];

    function ujetMediaListDirCtrl($scope, $controller, queryService, ujetMediaFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "MediaId"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            query: query,
            config: {
                objectFactory: ujetMediaFactory
            }
        });
    };
})();