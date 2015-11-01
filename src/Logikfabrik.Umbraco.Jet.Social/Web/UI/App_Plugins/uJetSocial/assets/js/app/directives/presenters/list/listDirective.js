angular.module('umbraco.directives')
    .directive('ujetList', ['_', function (_) {
        return {
            restrict: 'E',
            templateUrl: '/App_Plugins/uJetSocial/assets/js/app/directives/presenters/list/listView.html',
            scope: {
                ngModel: '='
            },
            transclude: true,
            link: function (scope, element, attrs) {
                scope._ = _;

                scope.sort = function(column) {
                    console.log(column);
                };
            }
        };
    }]);
