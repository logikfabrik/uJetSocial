﻿(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDocumentPickerDirCtrl", ujetDocumentPickerDirCtrl);

    ujetDocumentPickerDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetUmbracoDocumentFactory"];

    function ujetDocumentPickerDirCtrl($scope, $controller, queryService, ujetUmbracoDocumentFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoDocumentFactory,
                objectParam: "Name"
            },
            callback: function (obj) { alert("HEJ");}
        });
    };
})();