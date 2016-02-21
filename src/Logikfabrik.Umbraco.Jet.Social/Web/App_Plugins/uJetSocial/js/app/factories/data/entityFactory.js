(function () {
    'use strict';

    angular
        .module("umbraco.resources")
        .factory("ujetEntityFactory", ujetEntityFactory);

    ujetEntityFactory.$inject = [
        "$http",
        "ujetCommentFactory",
        "ujetGroupFactory",
        "ujetGuestFactory",
        "ujetReportFactory"
    ];
    
    function ujetEntityFactory($http, ujetCommentFactory, ujetGroupFactory, ujetGuestFactory, ujetReportFactory) {
        var factory = {
            getType: getType,
            getFactory: getFactory
        };

        return factory;

        function getType(id) {
            return $http.get("backoffice/uJetSocial/EntityAPI/GetType/" + id);
        }

        function getFactory(entityTypeName) {
            console.log(entityTypeName);

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
    };
})();