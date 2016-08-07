(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentCreateCtrl", ujetCommentCreateCtrl);

    ujetCommentCreateCtrl.$inject = ["$scope", "$controller", "$location", "notificationsService", "localService", "ujetCommentFactory"];

    function ujetCommentCreateCtrl($scope, $controller, $location, notificationsService, localService, ujetCommentFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetCommentFactory,
                path: "/uJetSocial/ujetComment/dashboard/-1",
                local: {
                    successCategory: "successCategoryAddComment",
                    success: "addCommentSuccess",
                    errorCategory: "errorCategoryAddComment",
                    error: "addCommentError"
                }
            }
        });
    };
})();