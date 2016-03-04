(function () {
    "use strict";

    angular
        .module("umbraco.directives")
        .directive("ujetValue", ujetValue);

    ujetValue.$inject = ["moment"];

    function ujetValue(moment) {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/value/valueView.html",
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