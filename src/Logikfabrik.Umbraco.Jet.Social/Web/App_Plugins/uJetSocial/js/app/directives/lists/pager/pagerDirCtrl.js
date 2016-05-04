(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetPagerDirCtrl", ujetPagerDirCtrl);

    ujetPagerDirCtrl.$inject = ["$scope"];

    function ujetPagerDirCtrl($scope) {
        var vm = {
            hasPages: false,
            goToPreviousPage: goToPreviousPage,
            goToNextPage: goToNextPage,
            goToFirstPage: goToFirstPage,
            goToLastPage: goToLastPage,
            goToPage: goToPage
        };

        $scope.vm = vm;

        function goToPreviousPage() {
            goToPage(vm.pageIndex - 1);
        };

        function goToNextPage() {
            goToPage(vm.pageIndex + 1);
        };

        function goToFirstPage() {
            goToPage(1);
        };

        function goToLastPage() {
            goToPage(vm.pageCount);
        };

        function goToPage(pageIndex) {
            if (pageIndex < 1 || pageIndex > vm.pageCount) {
                return;
            }

            $scope.$emit("pageIndexChanged", pageIndex);
        };

        $scope.$watch("model", function (newValue) {
            if (!_.isObject(newValue) || newValue.pageCount <= 1) {
                vm.hasPages = false;

                return;
            }

            vm.pageIndex = newValue.pageIndex;
            vm.pageCount = newValue.pageCount;

            vm.hasPages = true;
        });
    };
})();