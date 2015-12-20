﻿angular.module("umbraco")
    .controller("uJetSocial.reportEditController", [
        "$scope", "$routeParams", "navigationService", "_", "reportFactory",
        function ($scope, $routeParams, navigationService, _, reportFactory) {

            navigationService.syncTree({ tree: "report", path: ["-1", $routeParams.id], forceReload: false });
        }
    ]);