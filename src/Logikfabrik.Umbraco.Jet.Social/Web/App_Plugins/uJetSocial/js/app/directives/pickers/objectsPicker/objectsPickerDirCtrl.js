(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetObjectsPickerDirCtrl", ujetObjectsPickerDirCtrl);

    ujetObjectsPickerDirCtrl.$inject = ["$scope", "_", "dialogService", "ujetEntityFactory"];

    function ujetObjectsPickerDirCtrl($scope, _, dialogService, ujetEntityFactory) {
        var vm = {
            objIds: $scope.model,
            canPickComment: $scope.canPickComment,
            canPickDocument: $scope.canPickDocument,
            canPickGroup: $scope.canPickGroup,
            canPickGuest: $scope.canPickGuest,
            canPickMedia: $scope.canPickMedia,
            canPickMember: $scope.canPickMember,
            canPickReport: $scope.canPickReport,
            objs: [],
            hasObjects: false,
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
            if (_.indexOf(vm.objIds, obj.id) !== -1) {
                // The object is selected.
                return;
            }

            vm.objIds.push(obj.id);
            vm.objs.push(obj);
            vm.hasObjects = !_.isEmpty(vm.objIds);
        };

        function deselectObj(obj) {
            if (_.indexOf(vm.objIds, obj.id) === -1) {
                // The object is not selected.
                return;
            }

            vm.objIds = _.without(vm.objIds, obj.id);
            vm.objs.pop(obj);
            vm.hasObjects = !_.isEmpty(vm.objIds);
        };

        function init() {
            if (_.isNaN(vm.objId) || !_.isNumber(vm.objId)) {
                return;
            }

            ujetEntityFactory.get(vm.objId).then(function (obj) {
                selectObj(obj);
            });
        };

        $scope.$on("deleteObject", function (e, obj) {
            deselectObj(obj);
        });

        $scope.$watch("vm.objIds", function (newValue) {
            $scope.model = newValue;
        });

        init();
    };
})();