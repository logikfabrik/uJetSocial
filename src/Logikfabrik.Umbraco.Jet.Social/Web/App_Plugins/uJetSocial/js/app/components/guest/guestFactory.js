﻿angular.module("umbraco.resources")
    .factory("guestFactory", [
        "$http", function ($http) {
            var dataFactory = {};

            dataFactory.search = function (searchQuery) {
                return $http.post("backoffice/uJetSocial/GuestAPI/Search", searchQuery);
            };

            return dataFactory;
        }
    ]);