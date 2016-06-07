(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualMemberPickerDirCtrl", ujetIndividualMemberPickerDirCtrl);

    ujetIndividualMemberPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "queryService", "ujetUmbracoMemberFactory", "ujetIndividualMemberFactory"];

    function ujetIndividualMemberPickerDirCtrl($scope, $controller, $filter, queryService, ujetUmbracoMemberFactory, ujetIndividualMemberFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMemberFactory,
                objectParam: "Name"
            },
            callback: function (object) {
                ujetIndividualMemberFactory.getByMemberId(object.id).success(function (data) {
                    $scope.dialogOptions.callback($filter("ujetAsIndividualMember")(data));
                });
            }
        });
    };
})();