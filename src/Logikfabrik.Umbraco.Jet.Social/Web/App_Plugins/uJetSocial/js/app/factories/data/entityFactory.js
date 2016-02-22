(function () {
    'use strict';

    angular
        .module("umbraco.resources")
        .factory("ujetEntityFactory", ujetEntityFactory);

    ujetEntityFactory.$inject = [
        "$http",
        "$filter",
        "ujetCommentFactory",
        "ujetGroupFactory",
        "ujetGuestFactory",
        "ujetReportFactory"
    ];
    
    function ujetEntityFactory($http, $filter, ujetCommentFactory, ujetGroupFactory, ujetGuestFactory, ujetReportFactory) {
        var factory = {
            getType: getType,
            getFactory: getFactory,
            getFilter: getFilter
        };

        return factory;

        function getType(id) {
            return $http.get("backoffice/uJetSocial/EntityAPI/GetType/" + id);
        }

        function getFactory(entityTypeName) {
            switch (entityTypeName) {
                case "Comment":
                    return ujetCommentFactory;
                case "Group":
                    return ujetGroupFactory;
                case "IndividualGuest":
                    return ujetGuestFactory;
                case "Report":
                    return ujetReportFactory;
                default:
                    return null;
            }
        }

        function getFilter(entityTypeName) {
            switch (entityTypeName) {
                case "Comment":
                    return $filter("ujetAsComment");
                case "Group":
                    return $filter("ujetAsGroup");
                case "IndividualGuest":
                    return $filter("ujetAsGuest");
                case "Report":
                    return $filter("ujetAsReport");
                default:
                    return null;
            }
        }
    };
})();