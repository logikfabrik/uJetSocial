(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetObjectDirCtrl", ujetObjectDirCtrl);

    ujetObjectDirCtrl.$inject = ["$scope"];

    function ujetObjectDirCtrl($scope) {
        var vm = {
            obj: $scope.obj,
            canSelect: $scope.canSelect,
            canEdit: $scope.canEdit,
            canDelete: $scope.canDelete,
            selectObj: selectObj,
            editObj: editObj,
            deleteObj: deleteObj
        };

        console.log($scope.obj);

        $scope.vm = vm;

        function selectObj() {
            $scope.$emit("selectObject", vm.obj);
        };

        function editObj() {
            $scope.$emit("editObject", vm.obj);
        };

        function deleteObj() {
            $scope.$emit("deleteObject", vm.obj);
        };
    };
})();