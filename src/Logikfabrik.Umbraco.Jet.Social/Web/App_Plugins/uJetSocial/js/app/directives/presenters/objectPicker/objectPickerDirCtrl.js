(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetObjectPickerDirCtrl", ujetObjectPickerDirCtrl);

    ujetObjectPickerDirCtrl.$inject = ["$scope", "_", "dialogService"];

    function ujetObjectPickerDirCtrl($scope, _, dialogService) {
        var vm = {
            obj: $scope.obj,
            canPickPage: $scope.canPickPage,
            canPickComment: $scope.canPickComment,
            canPickGroup: $scope.canPickGroup,
            canPickGuest: $scope.canPickGuest,
            canPickUser: $scope.canPickUser,
            canPickReport: $scope.canPickReport,
            hasObject: false,
            showPicker: showPicker
        };

        $scope.vm = vm;

        var dialog;

        function showPicker(type) {
            if (!_.isNull(dialog)) {
                dialogService.close(dialog);
            }

            var template = "/App_Plugins/uJetSocial/backoffice/pickers/" + type + ".html";

            dialog = dialogService.open({
                template: template,
                callback: selectObj
            });

        };

        function selectObj(obj) {
            if (!_.isNull(dialog)) {
                dialogService.close(dialog);
            }

            vm.obj = obj;
            vm.hasObject = true;

            dialog = null;
        }

        $scope.$on("deleteObject", function (e) {
            vm.obj = null;
            vm.hasObject = false;
        });
    };
})();