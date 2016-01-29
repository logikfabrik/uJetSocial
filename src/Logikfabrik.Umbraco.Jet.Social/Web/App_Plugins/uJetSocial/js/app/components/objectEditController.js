angular.module("umbraco")
    .controller("uJetSocial.objectEditController", [
        "$scope", "_",
        function($scope, _) {

            $scope.model = _.clone($scope.dialogData);

            $scope.save = function(form) {
                if (!form.$valid) {
                    return;
                }

                $scope.dialogOptions.callback($scope.model);
            };
        }
    ]);