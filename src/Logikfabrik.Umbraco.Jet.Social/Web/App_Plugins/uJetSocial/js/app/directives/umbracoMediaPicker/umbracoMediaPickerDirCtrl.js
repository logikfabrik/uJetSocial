﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetUmbracoMediaPickerDirCtrl", ujetUmbracoMediaPickerDirCtrl);

    ujetUmbracoMediaPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "notificationsService", "localService", "queryService", "ujetUmbracoMediaFactory"];

    function ujetUmbracoMediaPickerDirCtrl($scope, $controller, $filter, notificationsService, localService, queryService, ujetUmbracoMediaFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMediaFactory,
                objectParam: "Name"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();