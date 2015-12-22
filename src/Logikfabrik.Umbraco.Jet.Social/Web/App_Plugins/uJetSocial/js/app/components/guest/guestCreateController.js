angular.module("umbraco")
    .controller("uJetSocial.guestCreateController", [
        "$scope", "$location", "guestFactory",
        function ($scope, $location, guestFactory) {
            var editPath = "/uJetSocial/guest/edit/";

            $scope.ngModel = {
                FirstName: "Förnamn",
                LastName: "Efternamn",
                Email: "E-post"
            };

            $scope.create = function () {
                guestFactory.add($scope.ngModel).success(function (id) {
                    $location.path(editPath + id);
                });
            };
        }
    ]);