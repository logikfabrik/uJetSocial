(function () {
    'use strict';

    angular
        .module("umbraco")
        .controller("ujetCommentPickerDirCtrl", ujetCommentPickerDirCtrl);

    ujetCommentPickerDirCtrl.$inject = ["$scope", "$controller", "ujetCommentFactory", "queryService"];

    function ujetCommentPickerDirCtrl($scope, $controller, objectFactory, queryService) {
        $controller('ujetPickerCtrl', {
            $scope: $scope,
            objectFactory: objectFactory,
            queryService: queryService
        });
    };
})();