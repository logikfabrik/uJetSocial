(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualMemberListDirCtrl", ujetIndividualMemberListDirCtrl);

    ujetIndividualMemberListDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetIndividualMemberFactory"];

    function ujetIndividualMemberListDirCtrl($scope, $controller, queryService, ujetIndividualMemberFactory) {
        var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "MemberId"]);

        $controller("ujetListCtrl", {
            $scope: $scope,
            query: query,
            config: {
                objectFactory: ujetIndividualMemberFactory
            }
        });
    };
})();