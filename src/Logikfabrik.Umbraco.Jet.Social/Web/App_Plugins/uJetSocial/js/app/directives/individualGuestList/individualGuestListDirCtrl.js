(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualGuestListDirCtrl", ujetIndividualGuestListDirCtrl);

    ujetIndividualGuestListDirCtrl.$inject = ["$scope", "$controller", "$routeParams", "queryService", "ujetIndividualGuestFactory"];

    function ujetIndividualGuestListDirCtrl($scope, $controller, $routeParams, queryService, ujetIndividualGuestFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "FirstName", "LastName"]);

        var config = {
            objectFactory: ujetIndividualGuestFactory
        };

        if (isNaN(parseInt($routeParams.id, 10))) {
            config.searchParams = { firstName: $routeParams.id }
        }

        $controller("ujetListCtrl", {
            $scope: $scope,
            query: query,
            config: config
        });
    };
})();