(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMediaPickerDirCtrl", ujetMediaPickerDirCtrl);

    ujetMediaPickerDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetUmbracoMediaFactory"];

    function ujetMediaPickerDirCtrl($scope, $controller, queryService, ujetUmbracoMediaFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMediaFactory,
                objectParam: "Name"
            },
            callback: function (obj) { alert("HEJ");}
        });
    };
})();