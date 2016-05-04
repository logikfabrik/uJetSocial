(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco.resources")
        .factory("ujetCommentFactory", ujetCommentFactory);

    ujetCommentFactory.$inject = ["$http"];

    function ujetCommentFactory($http) {
        var factory = {
            add: add,
            update: update,
            get: get,
            query: query
        };

        return factory;

        function add(dto) {
            return $http.post("backoffice/uJetSocial/CommentAPI/Add", dto);
        }

        function update(dto) {
            return $http({
                method: "POST",
                url: "backoffice/uJetSocial/CommentAPI/Update",
                params: {
                    id: dto.id
                },
                data: dto
            });
        }

        function get(id) {
            return $http.get("backoffice/uJetSocial/CommentAPI/Get/" + id);
        }

        function query(q) {
            return $http.post("backoffice/uJetSocial/CommentAPI/Query", q);
        }
    };
})();