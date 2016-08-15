(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetCommentCreateCtrl", ujetCommentCreateCtrl);

    ujetCommentCreateCtrl.$inject = ["$scope", "$controller", "$location", "$route", "notificationsService", "localService", "ujetCommentFactory"];

    function ujetCommentCreateCtrl($scope, $controller, $location, $route, notificationsService, localService, ujetCommentFactory) {
        $controller("ujetObjectCreateCtrl", {
            $scope: $scope,
            $location: $location,
            $route: $route,
            notificationsService: notificationsService,
            localService: localService,
            config: {
                objectFactory: ujetCommentFactory,
                path: "/uJetSocial/ujetComment/dashboard/-1",
                local: {
                    successCategory: "uJetSocial_successCategoryAddComment",
                    success: "uJetSocial_addCommentSuccess",
                    errorCategory: "uJetSocial_errorCategoryAddComment",
                    error: "uJetSocial_addCommentError"
                }
            }
        });
    };
})();