(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetObjectPickerDirCtrl", ujetObjectPickerDirCtrl);

    ujetObjectPickerDirCtrl.$inject = ["$scope", "_", "dialogService"];

    function ujetObjectPickerDirCtrl($scope, _, dialogService) {
        var vm = {
            obj: $scope.obj,
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

            dialog = null;
        }
    };
})();