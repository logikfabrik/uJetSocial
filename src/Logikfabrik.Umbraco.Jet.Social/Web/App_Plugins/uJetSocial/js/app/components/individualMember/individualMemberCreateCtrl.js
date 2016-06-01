(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualMemberCreateCtrl", ujetIndividualMemberCreateCtrl);

    ujetIndividualMemberCreateCtrl.$inject = ["$scope", "$controller", "$location", "notificationsService", "ujetIndividualMemberFactory"];

    function ujetIndividualMemberCreateCtrl($scope, $controller, $location, notificationsService, ujetIndividualMemberFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetIndividualMemberFactory,
                path: "/uJetSocial/ujetIndividualMember/dashboard/-1",
                createSuccessMessage: "Member created",
                createErrorMessage: "Member could not be created"
            }
        });
    };
})();