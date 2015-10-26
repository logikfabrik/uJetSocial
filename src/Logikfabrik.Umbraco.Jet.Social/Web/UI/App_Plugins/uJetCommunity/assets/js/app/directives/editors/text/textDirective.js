angular.module('umbraco.directives')
    .directive('ujetText', [function () {
        return {
            restrict: 'E',
            templateUrl: '/App_Plugins/uJetCommunity/assets/js/app/directives/editors/text/textView.html',
            scope: {
                id: '@',
                label: '@',
                desciption: '@',
                ngModel: '='
            },
            link: function (scope, element, attrs) {
            }
        };
    }]);
