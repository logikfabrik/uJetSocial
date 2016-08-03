angular.module("umbraco.services")
    .service("localService", [
        "$q", "localizationService", "_", function ($q, localizationService, _) {
            var dataService = {};

            dataService.localize = function(keys) {
                var localizations = {};

                _.forOwn(keys, function(value, key) {
                    localizationService.localize("uJetSocial_" + key)
                        .then(function(trans) {
                            _.set(localizations, key, trans);
                        });
                });

                return localizations;
            };
            
            return dataService;
        }
    ]);