(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetObjectDirCtrl", ujetObjectDirCtrl);

    ujetObjectDirCtrl.$inject = ["$scope"];

    function ujetObjectDirCtrl($scope) {
        var vm = {
            canSelect: $scope.canSelect,
            canEdit: $scope.canEdit,
            canDelete: $scope.canDelete,
            selectObject: selectObject,
            editObject: editObject,
            deleteObject: deleteObject
        };

        $scope.vm = vm;

        function selectObject() {
            $scope.$emit("selectObject", vm.object);
        };

        function editObject() {
            $scope.$emit("editObject", vm.object);
        };

        function deleteObject() {
            $scope.$emit("deleteObject", vm.object);
        };

        $scope.$watch("model", function (newValue) {
            if (_.isNull(newValue) ||
                _.isUndefined(newValue)) {
                return;
            }

            vm.object = newValue;
        });
    };
})();