(function () {
    'use strict';

    angular
        .module("umbraco.directives")
        .directive("ujetObjectStatusSelect", ujetObjectStatusSelect);

    ujetObjectStatusSelect.$inject = ["_"];

    function ujetObjectStatusSelect(_) {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/objectStatusSelect/objectStatusSelectView.html",
            scope: {
                ngModel: "="
            },
            link: link
        };

        return directive;

        function link(scope, element, attrs) {
            scope._ = _;
        }
    };
})();