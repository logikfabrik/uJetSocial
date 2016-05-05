(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetMemberPickerDirCtrl", ujetMemberPickerDirCtrl);

    ujetMemberPickerDirCtrl.$inject = ["$scope", "$controller", "queryService", "ujetUmbracoMemberFactory"];

    function ujetMemberPickerDirCtrl($scope, $controller, queryService, ujetUmbracoMemberFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoMemberFactory,
                objectParam: "Name"
            },
            callback: function (obj) { alert("HEJ");}
        });
    };
})();