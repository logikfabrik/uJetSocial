(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetGuestPickerDirCtrl", ujetGuestPickerDirCtrl);

    ujetGuestPickerDirCtrl.$inject = ["$scope", "$controller", "ujetGuestFactory", "queryService"];

    function ujetGuestPickerDirCtrl($scope, $controller, objectFactory, queryService) {
        $controller('ujetPickerCtrl', {
            $scope: $scope,
            objectFactory: objectFactory,
            queryService: queryService,
            param: "FirstName"
        });
    };
})();