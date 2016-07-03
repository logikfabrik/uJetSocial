(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetNodePickerDirCtrl", ujetNodePickerDirCtrl);

    ujetNodePickerDirCtrl.$inject = ["$scope", "_", "dialogService", "ujetUmbracoNodeTypeFactory"];

    function ujetNodePickerDirCtrl($scope, _, dialogService, ujetUmbracoNodeTypeFactory) {
        var vm = {
            canPickDocument: $scope.canPickDocument,
            canPickMedia: $scope.canPickMedia,
            canPickMember: $scope.canPickMember,
            showPicker: showPicker
        };

        $scope.vm = vm;

        var dialog;

        function showPicker(type) {
            if (dialog !== null) {
                dialogService.close(dialog);
            }

            var template = "/App_Plugins/uJetSocial/js/app/directives/" + type + "Picker/" + type + "PickerDialogView.html";

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

            ujetUmbracoNodeTypeFactory.get(newValue).then(function (object) {
                selectObject(object);
            });
        });
    };
})();