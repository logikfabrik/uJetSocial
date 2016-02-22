(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetObjectPickerDirCtrl", ujetObjectPickerDirCtrl);

    ujetObjectPickerDirCtrl.$inject = ["$scope", "_", "dialogService", "ujetEntityFactory"];

    function ujetObjectPickerDirCtrl($scope, _, dialogService, ujetEntityFactory) {
        var vm = {
            objId: $scope.model,
            canPickPage: $scope.canPickPage,
            canPickComment: $scope.canPickComment,
            canPickGroup: $scope.canPickGroup,
            canPickGuest: $scope.canPickGuest,
            canPickUser: $scope.canPickUser,
            canPickReport: $scope.canPickReport,
            obj: null,
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
                callback: function (obj) {
                    if (!_.isNull(dialog)) {
                        dialogService.close(dialog);
                    }

                    selectObj(obj);

                    dialog = null;
                }
            });
        };

        function selectObj(obj) {
            vm.objId = obj.Id;
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

            ujetEntityFactory.getType(vm.objId).success(function(type) {
                var factory = ujetEntityFactory.getFactory(type.Name);

                factory.get(vm.objId).success(function (obj) {
                    var filter = ujetEntityFactory.getFilter(type.Name);

                    selectObj(filter(obj));
                });
            });
        };

        $scope.$on("deleteObject", function (e) {
            deselectObj();
        });

        $scope.$watch("vm.objId", function(newValue, oldValue) {
            $scope.model = newValue;
        });

        init();
    };
})();