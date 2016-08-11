(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetSpinnerDirCtrl", ujetSpinnerDirCtrl);

    ujetSpinnerDirCtrl.$inject = ["$scope", "$http"];

    function ujetSpinnerDirCtrl($scope, $http) {
        var vm = {
            isLoading: isLoading
        };

        $scope.vm = vm;

        function isLoading() {
            return $http.pendingRequests.length > 0;
        }
    };
})();