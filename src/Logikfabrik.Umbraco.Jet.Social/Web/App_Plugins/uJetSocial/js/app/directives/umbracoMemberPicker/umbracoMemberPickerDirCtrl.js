﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetUmbracoMemberPickerDirCtrl", ujetUmbracoMemberPickerDirCtrl);

    ujetUmbracoMemberPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "notificationsService", "localService", "queryService", "ujetUmbracoMemberFactory"];

    function ujetUmbracoMemberPickerDirCtrl($scope, $controller, $filter, notificationsService, localService, queryService, ujetUmbracoMemberFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMemberFactory,
                objectParam: "Name"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();