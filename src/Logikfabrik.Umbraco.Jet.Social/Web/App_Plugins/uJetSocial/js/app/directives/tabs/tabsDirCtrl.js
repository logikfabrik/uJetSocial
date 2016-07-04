(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetTabsDirCtrl", ujetTabsDirCtrl);

    function ujetTabsDirCtrl($scope) {
        var vm = {
            tabs: [],
            selectTab: selectTab
        };

        $scope.vm = vm;
        
        function selectTab(tab) {
            for (var i = 0; i < vm.tabs.length; i++) {
                vm.tabs[i].isActive = false;
            }

            tab.isActive = true;
        };

        this.addTab = function (tab) {
            vm.tabs.push(tab);

            if (vm.tabs.length === 1) {
                vm.tabs[0].isActive = true;
            }
        };
    };
})();