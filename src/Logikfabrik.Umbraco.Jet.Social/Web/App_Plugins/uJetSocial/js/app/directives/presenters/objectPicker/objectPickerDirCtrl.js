(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetObjectPickerDirCtrl", ujetObjectPickerDirCtrl);

    ujetObjectPickerDirCtrl.$inject = ["$scope", "_", "dialogService", "ujetEntityFactory"];

    function ujetObjectPickerDirCtrl($scope, _, dialogService, ujetEntityFactory) {
        var vm = {
            model: $scope.model,
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
            console.log(obj);

            $scope.model = obj.Id;
            vm.obj = obj;
            vm.hasObject = true;

            console.log($scope.model);
        };

        function deselectObj() {
            $scope.model = null;
            vm.obj = null;
            vm.hasObject = false;
        };

        function init() {
            if (_.isNaN($scope.model) || !_.isNumber($scope.model)) {
                return;
            }

            ujetEntityFactory.getType($scope.model).success(function (type) {
                var factory = ujetEntityFactory.getFactory(type.Name);

                factory.get($scope.model).success(function (obj) {
                    selectObj(obj);
                });
            });
        };

        $scope.$on("deleteObject", function (e) {
            deselectObj();
        });

        init();
    };
})();