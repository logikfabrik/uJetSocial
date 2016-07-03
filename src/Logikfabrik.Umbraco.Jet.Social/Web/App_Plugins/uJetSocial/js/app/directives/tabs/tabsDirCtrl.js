(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetTabsDirCtrl", ujetTabsDirCtrl);

    function ujetTabsDirCtrl($scope) {
        var vm = {
            tabs: [],
            addTab: addTab,
            selectTab: selectTab
        };

        $scope.vm = vm;

        function addTab(tab) {
            vm.tabs.push(tab);
        };

        function selectTab(tab) {
            for (var i = 0; i < vm.tabs.length; i++) {
                vm.tabs[i].isActive = false;
            }

            tab.isActive = true;
        };
    };
})();