(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetUmbracoMediaFactory", ujetUmbracoMediaFactory);

    ujetUmbracoMediaFactory.$inject = ["$http"];

    function ujetUmbracoMediaFactory($http) {
        var factory = {
        };

        return factory;
    };
})();