(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentCreateCtrl", ujetCommentCreateCtrl);

    ujetCommentCreateCtrl.$inject = ["$scope", "$controller", "$location", "notificationsService", "ujetCommentFactory"];

    function ujetCommentCreateCtrl($scope, $controller, $location, notificationsService, ujetCommentFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            notificationsService: notificationsService,
            config: {
                objectFactory: ujetCommentFactory,
                path: "/uJetSocial/ujetComment/dashboard/-1",
                createSuccessMessage: "Comment created",
                createErrorMessage: "Comment could not be created"
            }
        });
    };
})();