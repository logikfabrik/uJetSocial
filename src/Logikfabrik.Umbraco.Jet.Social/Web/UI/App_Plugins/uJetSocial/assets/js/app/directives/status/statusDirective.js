angular.module('umbraco.directives')
    .directive('status', [function () {
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/App_Plugins/uJetSocial/assets/js/app/directives/status/statusView.html',
            scope: {
                entity: '='
            },
            link: function (scope, element, attrs) {
                function getKey(status) {
                    switch (status) {
                        case 0:
                            return "sections_uJetSocial_general_status_pending";
                        case 1:
                            return "sections_uJetSocial_general_status_approved";
                        case 2:
                            return "sections_uJetSocial_general_status_rejected";
                        default:
                            return null;
                    }
                };

                scope.key = getKey(scope.entity.Status);
            }
        };
    }]);
