(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualMemberListDirCtrl", ujetIndividualMemberListDirCtrl);

    ujetIndividualMemberListDirCtrl.$inject = ["$scope", "$controller", "notificationsService", "localService", "queryService", "ujetIndividualMemberFactory"];

    function ujetIndividualMemberListDirCtrl($scope, $controller, notificationsService, localService, queryService, ujetIndividualMemberFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "MemberId"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            query: query,
            config: {
                objectFactory: ujetIndividualMemberFactory
            }
        });
    };
})();