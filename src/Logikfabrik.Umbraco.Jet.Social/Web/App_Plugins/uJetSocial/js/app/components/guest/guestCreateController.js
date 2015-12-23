angular.module("umbraco")
    .controller("uJetSocial.guestCreateController", [
        "$scope", "$location", "guestFactory",
        function ($scope, $location, guestFactory) {
            $scope.ngModel = {
                FirstName: "Förnamn",
                LastName: "Efternamn",
                Email: "E-post"
            };

            $scope.create = function () {
                guestFactory.add($scope.ngModel).success(function (id) {
                    $location.path("/uJetSocial/guest/edit/" + id);
                });
            };
        }
    ]);