(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetIndividualMemberPickerDirCtrl", ujetIndividualMemberPickerDirCtrl);

    ujetIndividualMemberPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "notificationsService", "localService", "queryService", "ujetUmbracoMemberFactory", "ujetIndividualMemberFactory"];

    function ujetIndividualMemberPickerDirCtrl($scope, $controller, $filter, notificationsService, localService, queryService, ujetUmbracoMemberFactory, ujetIndividualMemberFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMemberFactory,
                objectParam: "Name"
            },
            callback: function (object) {
                ujetIndividualMemberFactory.getByMemberId(object.id)
                    .then(function(response) {
                        $scope.dialogOptions.callback($filter("ujetAsIndividualMember")(response.data));
                    });
            }
        });
    };
})();