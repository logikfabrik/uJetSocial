angular.module('umbraco.directives')
    .directive('ujetEditor', ['localizationService', function (localizationService) {
        return {
            restrict: 'E',
            templateUrl: '/App_Plugins/uJetCommunity/assets/js/app/directives/editors/editor/editorView.html',
            scope: {
                id: '@',
                label: '@',
                desciption: '@'
            },
            transclude: true,
            link: function (scope, element, attrs) {
                localizationService.localize(scope.label).then(function (value) {
                    scope.localLabel = value;
                });
                
                localizationService.localize(scope.desciption).then(function (value) {
                    scope.localDesciption = value;
                });
            }
        };
    }]);
