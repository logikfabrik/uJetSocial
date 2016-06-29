﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDocumentPickerDirCtrl", ujetDocumentPickerDirCtrl);

    ujetDocumentPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "localizationService", "queryService", "ujetUmbracoDocumentFactory", "ujetDocumentFactory"];

    function ujetDocumentPickerDirCtrl($scope, $controller, $filter, localizationService, queryService, ujetUmbracoDocumentFactory, ujetDocumentFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            localizationService: localizationService,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoDocumentFactory,
                objectParam: "Name"
            },
            callback: function(object) {
                ujetDocumentFactory.getByDocumentId(object.id).success(function (data) {
                    $scope.dialogOptions.callback($filter("ujetAsDocument")(data));
                });
            }
        });
    };
})();