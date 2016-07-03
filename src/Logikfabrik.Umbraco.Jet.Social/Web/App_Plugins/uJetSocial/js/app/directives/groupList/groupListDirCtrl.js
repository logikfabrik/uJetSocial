(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupListDirCtrl", ujetGroupListDirCtrl);

    ujetGroupListDirCtrl.$inject = ["$scope", "$controller", "$routeParams", "queryService", "ujetGroupFactory"];

    function ujetGroupListDirCtrl($scope, $controller, $routeParams, queryService, ujetGroupFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "Name", "Description", "OwnerId"]);

        var config = {
            objectFactory: ujetGroupFactory
        };

        if (isNaN(parseInt($routeParams.id, 10))) {
            config.searchParams = { name: $routeParams.id }
        }

        $controller("ujetListCtrl", {
            $scope: $scope,
            query: query,
            config: config
        });
    };
})();