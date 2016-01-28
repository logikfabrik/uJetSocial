angular.module("umbraco.services")
    .service("queryService", [
        "_", function(_) {
            var dataService = {};

            dataService.getQuery = function(orderByOptions) {
                var query = {};

                query.PageIndex = {
                    Value: 1
                };

                query.PageSize = {
                    Value: 20,
                    Min: 10,
                    Max: 100,
                    Step: 10
                };

                query.OrderBy = {
                    Value: _.head(orderByOptions),
                    Options: orderByOptions
                };

                query.compile = function(params) {
                    var q = {
                        PageIndex: query.PageIndex.Value - 1,
                        PageSize: query.PageSize.Value,
                        OrderBy: query.OrderBy.Value
                    };

                    if (!_.isNull(params)) {
                        _.forOwn(params, function(value, key) {
                            _.set(q, key, value);
                        });
                    }

                    return q;
                };

                return query;
            };

            return dataService;
        }
    ]);