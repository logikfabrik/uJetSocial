(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.directives")
        .directive("ujetValue", ujetValueDir);

    ujetValueDir.$inject = ["moment"];

    function ujetValueDir(moment) {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/value/valueView.html",
            scope: {
                value: "@"
            },
            link: link
        };

        return directive;

        function link(scope, element, attrs) {
            scope.isDate = moment(scope.value, moment.ISO_8601, true).isValid();
        }
    };
})();