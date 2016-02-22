(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetGroupPickerDirCtrl", ujetGroupPickerDirCtrl);

    ujetGroupPickerDirCtrl.$inject = ["$scope", "$controller", "ujetGroupFactory", "queryService"];

    function ujetGroupPickerDirCtrl($scope, $controller, objectFactory, queryService) {
        $controller('ujetPickerCtrl', {
            $scope: $scope,
            objectFactory: objectFactory,
            queryService: queryService,
            param: "Name"
        });
    };
})();