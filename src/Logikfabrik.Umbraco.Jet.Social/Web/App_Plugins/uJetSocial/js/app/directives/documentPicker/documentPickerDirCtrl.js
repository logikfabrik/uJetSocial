(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetDocumentPickerDirCtrl", ujetDocumentPickerDirCtrl);

    ujetDocumentPickerDirCtrl.$inject = ["$scope", "$controller", "$filter", "notificationsService", "localService", "queryService", "ujetUmbracoDocumentFactory", "ujetDocumentFactory"];

    function ujetDocumentPickerDirCtrl($scope, $controller, $filter, notificationsService, localService, queryService, ujetUmbracoDocumentFactory, ujetDocumentFactory) {
        $controller("ujetPickerCtrl", {
            $scope: $scope,
            notificationsService: notificationsService,
            localService: localService,
            queryService: queryService,
            config: {
                objectFactory: ujetUmbracoDocumentFactory,
                objectParam: "Name"
            },
            callback: function(object) {
                ujetDocumentFactory.getByDocumentId(object.id)
                    .then(function(response) {
                        $scope.dialogOptions.callback($filter("ujetAsDocument")(response.data));
                    });
            }
        });
    };
})();