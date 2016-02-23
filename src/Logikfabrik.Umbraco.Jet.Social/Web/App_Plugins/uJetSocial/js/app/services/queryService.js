angular.module("umbraco.services")
    .service("queryService", [
        "_", function(_) {
            var dataService = {};

            dataService.getQuery = function(orderByOptions) {
                var query = {};

                query.pageIndex = {
                    value: 1
                };

                query.pageSize = {
                    value: 20,
                    min: 10,
                    max: 100,
                    step: 10
                };

                query.orderBy = {
                    value: _.head(orderByOptions),
                    options: orderByOptions
                };

                query.compile = function(params) {
                    var q = {
                        pageIndex: query.pageIndex.value - 1,
                        pageSize: query.pageSize.value,
                        orderBy: query.orderBy.value
                    };

                    if (!_.isNull(params) && !_.isUndefined(params)) {
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