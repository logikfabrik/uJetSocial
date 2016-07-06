(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetLabelDirCtrl", ujetLabelDirCtrl);

    ujetLabelDirCtrl.$inject = ["$scope"];

    function ujetLabelDirCtrl($scope) {
        var vm = {
            titleKey: $scope.titleKey,
            descriptionKey: $scope.descriptionKey,
            showTitle: ($scope.titleKey) ? true : false,
            showDescription: ($scope.descriptionKey) ? true : false
        };

        $scope.vm = vm;
    };
})();