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
                header: "@"
            },
            transclude: true,
            require: '^ujetTabs',
            link: link
        };

        return directive;

        function link(scope, element, attrs, parentCtrl) {
            var vm = {
                header: scope.header,
                isActive: false
            };

            scope.vm = vm;

            parentCtrl.addTab(vm);
        }
    };
})();