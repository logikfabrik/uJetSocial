angular.module("umbraco.directives")
    .directive("ujetIndividualSelect", [
        "_", "guestFactory", "queryService",
        function (_, guestFactory, queryService) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/individualSelect/individualSelectView.html",
                scope: {
                    ngModel: "="
                },
                link: function (scope, element, attrs) {
                    scope._ = _;

                    scope.objects = null;
                    scope.selectedObj = null;

                    scope.search = function () {
                        var q = queryService.getQuery().compile({ "FirstName": scope.query });

                        guestFactory.query(q).success(function (data) {
                            scope.objects = data.Objects;
                        });
                    };

                    scope.deselectObj = function () {
                        scope.selectedObj = null;
                        scope.ngModel = null;
                    };

                    scope.selectObj = function (obj) {
                        scope.selectedObj = obj;
                        scope.ngModel = obj.Id;

                        scope.objects = null;
                        scope.query = null;
                    };

                    scope.$watch('ngModel', function () {
                        var q = queryService.getQuery().compile({ "Id": scope.ngModel });

                        guestFactory.query(q).success(function (data) {
                            if (_.size(data.Objects) !== 1) {
                                return;
                            }

                            scope.selectedObj = data.Objects[0];
                        });
                    });
                }
            };
        }
    ]);