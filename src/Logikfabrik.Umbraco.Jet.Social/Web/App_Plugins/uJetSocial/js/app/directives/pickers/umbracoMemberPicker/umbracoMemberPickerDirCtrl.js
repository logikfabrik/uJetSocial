(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetUmbracoMemberPickerDirCtrl", ujetUmbracoMemberPickerDirCtrl);

    ujetUmbracoMemberPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "queryService", "ujetUmbracoMemberFactory"];

    function ujetUmbracoMemberPickerDirCtrl($scope, $controller, $filter, queryService, ujetUmbracoMemberFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMemberFactory,
                objectParam: "Name"
            },
            callback: $scope.dialogOptions.callback
        });
    };
})();