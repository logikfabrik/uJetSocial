(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetUmbracoMemberPickerDirCtrl", ujetUmbracoMemberPickerDirCtrl);

    ujetUmbracoMemberPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "localizationService", "queryService", "ujetUmbracoMemberFactory"];

    function ujetUmbracoMemberPickerDirCtrl($scope, $controller, $filter, localizationService, queryService, ujetUmbracoMemberFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            localizationService: localizationService,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMemberFactory,
                objectParam: "Name"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();