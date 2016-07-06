(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetTab", ujetTabDir);

    function ujetTabDir() {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/tab/tabView.html",
            scope: {
                headerKey: "@"
            },
            transclude: true,
            require: '^ujetTabs',
            link: link
        };

        return directive;

        function link(scope, element, attrs, parentCtrl) {
            var vm = {
                headerKey: scope.headerKey,
                isActive: false
            };

            scope.vm = vm;

            parentCtrl.addTab(vm);
        }
    };
})();