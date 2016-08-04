(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMediaPickerDirCtrl", ujetMediaPickerDirCtrl);

    ujetMediaPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "notificationsService", "localService", "queryService", "ujetUmbracoMediaFactory", "ujetMediaFactory"];

    function ujetMediaPickerDirCtrl($scope, $controller, $filter, notificationsService, localService, queryService, ujetUmbracoMediaFactory, ujetMediaFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMediaFactory,
                objectParam: "Name"
            },
            callback: function (object) {
                ujetMediaFactory.getByMediaId(object.id)
                    .then(function(response) {
                        $scope.dialogOptions.callback($filter("ujetAsMedia")(response.data));
                    });
            }
        });
    };
})();