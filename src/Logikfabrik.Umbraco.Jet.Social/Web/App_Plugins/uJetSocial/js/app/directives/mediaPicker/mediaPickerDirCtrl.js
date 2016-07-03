(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMediaPickerDirCtrl", ujetMediaPickerDirCtrl);

    ujetMediaPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "localizationService", "queryService", "ujetUmbracoMediaFactory", "ujetMediaFactory"];

    function ujetMediaPickerDirCtrl($scope, $controller, $filter, localizationService, queryService, ujetUmbracoMediaFactory, ujetMediaFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            localizationService: localizationService,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMediaFactory,
                objectParam: "Name"
            },
            callback: function (object) {
                ujetMediaFactory.getByMediaId(object.id).success(function (data) {
                    $scope.dialogOptions.callback($filter("ujetAsMedia")(data));
                });
            }
        });
    };
})();