(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMemberPickerDirCtrl", ujetMemberPickerDirCtrl);

    ujetMemberPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "queryService", "ujetUmbracoMemberFactory", "ujetMemberFactory"];

    function ujetMemberPickerDirCtrl($scope, $controller, $filter, queryService, ujetUmbracoMemberFactory, ujetMemberFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMemberFactory,
                objectParam: "Name"
            },
            callback: function (obj) {
                ujetMemberFactory.getByMemberId(obj.id).success(function (data) {
                    $scope.dialogOptions.callback($filter("ujetAsMember")(data));
                });
            }
        });
    };
})();