(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMediaListDirCtrl", ujetMediaListDirCtrl);

    ujetMediaListDirCtrl.$inject = ["$scope", "$controller", "notificationsService", "localService", "queryService", "ujetMediaFactory"];

    function ujetMediaListDirCtrl($scope, $controller, notificationsService, localService, queryService, ujetMediaFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "MediaId"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            query: query,
            config: {
                objectFactory: ujetMediaFactory
            }
        });
    };
})();