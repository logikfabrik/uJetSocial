(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetObjectPickerDirCtrl", ujetObjectPickerDirCtrl);

    ujetObjectPickerDirCtrl.$inject = ["$scope", "_", "dialogService", "ujetEntityFactory"];

    function ujetObjectPickerDirCtrl($scope, _, dialogService, ujetEntityFactory) {
        var vm = {
            canPickComment: $scope.canPickComment,
            canPickDocument: $scope.canPickDocument,
            canPickGroup: $scope.canPickGroup,
            canPickGuest: $scope.canPickGuest,
            canPickMedia: $scope.canPickMedia,
            canPickMember: $scope.canPickMember,
            canPickReport: $scope.canPickReport,
            showPicker: showPicker
        };

        $scope.vm = vm;

        var dialog;

        function showPicker(type) {
            if (dialog !== null) {
                dialogService.close(dialog);
            }

            var template = "/App_Plugins/uJetSocial/js/app/directives/pickers/" + type + "Picker/" + type + "PickerDialogView.html";

            dialog = dialogService.open({
                template: template,
                callback: function (object) {
                    if (dialog !== null) {
                        dialogService.close(dialog);
                    }

                    if (object !== null) {
                        selectObject(object);
                    }

                    dialog = null;
                }
            });
        };

        function selectObject(object) {
            $scope.model = object.id;

            vm.object = object;
            vm.hasObject = true;
        };

        function deselectObject() {
            $scope.model = null;

            vm.object = null;
            vm.hasObject = false;
        };

        $scope.$on("deleteObject", function (e) {
            deselectObject();
        });

        $scope.$watch("model", function (newValue) {
            if (_.isNull(newValue) ||
                _.isUndefined(newValue) ||
                _.isNaN(newValue)) {
                vm.object = null;
                vm.hasObject = false;

                return;
            }

            ujetEntityFactory.get(newValue).then(function (object) {
                selectObject(object);
            });
        });
    };
})();