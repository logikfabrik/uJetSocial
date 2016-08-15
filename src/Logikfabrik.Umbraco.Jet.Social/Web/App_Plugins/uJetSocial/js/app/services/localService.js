angular.module("umbraco.services")
    .service("localService", [
        "$q", "localizationService", "_", function ($q, localizationService, _) {
            var dataService = {};

            dataService.localize = function(keys) {
                var localizations = {};

                _.forOwn(keys, function (value, key) {
                    var langKey = (value === null) ? "uJetSocial_" + key : value;

                    if (_.isUndefined(langKey)) {
                        return;
                    }

                    localizationService.localize(langKey)
                        .then(function(trans) {
                            _.set(localizations, key, trans);
                        });
                });

                return localizations;
            };
            
            return dataService;
        }
    ]);