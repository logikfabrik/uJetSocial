(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualMemberPickerDirCtrl", ujetIndividualMemberPickerDirCtrl);

    ujetIndividualMemberPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "localizationService", "queryService", "ujetUmbracoMemberFactory", "ujetIndividualMemberFactory"];

    function ujetIndividualMemberPickerDirCtrl($scope, $controller, $filter, localizationService, queryService, ujetUmbracoMemberFactory, ujetIndividualMemberFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            localizationService: localizationService,
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