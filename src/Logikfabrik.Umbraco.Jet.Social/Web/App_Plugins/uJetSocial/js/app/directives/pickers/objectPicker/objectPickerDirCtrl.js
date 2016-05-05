(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetObjectPickerDirCtrl", ujetObjectPickerDirCtrl);

    ujetObjectPickerDirCtrl.$inject = ["$scope", "_", "dialogService", "ujetEntityFactory"];

    function ujetObjectPickerDirCtrl($scope, _, dialogService, ujetEntityFactory) {
        var vm = {
            objId: $scope.model,
            canPickComment: $scope.canPickComment,
            canPickDocument: $scope.canPickDocument,
            canPickGroup: $scope.canPickGroup,
            canPickGuest: $scope.canPickGuest,
            canPickMedia: $scope.canPickMedia,
            canPickMember: $scope.canPickMember,
            canPickReport: $scope.canPickReport,
            obj: null,
            hasObject: false,
            showPicker: showPicker
        };

        $scope.vm = vm;

        var dialog;

        function showPicker(type) {
            if (dialog !== null) {
                dialogService.close(dialog);
            }

            var template = "/App_Plugins/uJetSocial/backoffice/pickers/" + type + ".html";

            dialog = dialogService.open({
                template: template,
                callback: function (obj) {
                    if (dialog !== null) {
                        dialogService.close(dialog);
                    }

                    if (obj !== null) {
                        selectObj(obj);
                    }

                    dialog = null;
                }
            });
        };

        function selectObj(obj) {
            vm.objId = obj.id;
            vm.obj = obj;
            vm.hasObject = true;
        };

        function deselectObj() {
            vm.objId = null;
            vm.obj = null;
            vm.hasObject = false;
        };

        function init() {
            if (_.isNaN(vm.objId) || !_.isNumber(vm.objId)) {
                return;
            }

            ujetEntityFactory.get(vm.objId).then(function (obj) {
                selectObj(obj);
            });
        };

        $scope.$on("deleteObject", function (e) {
            deselectObj();
        });

        $scope.$watch("vm.objId", function (newValue) {
            $scope.model = newValue;
        });

        init();
    };
})();