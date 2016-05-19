(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMediaPickerDirCtrl", ujetMediaPickerDirCtrl);

    ujetMediaPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "queryService", "ujetUmbracoMediaFactory", "ujetMediaFactory"];

    function ujetMediaPickerDirCtrl($scope, $controller, $filter, queryService, ujetUmbracoMediaFactory, ujetMediaFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMediaFactory,
                objectParam: "Name"
            },
            callback: function (obj) {
                ujetMediaFactory.getByMediaId(obj.id).success(function (data) {
                    $scope.dialogOptions.callback($filter("ujetAsMedia")(data));
                });
            }
        });
    };
})();