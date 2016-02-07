(function () {
    'use strict';

    angular
        .module("umbraco.directives")
        .directive("ujetCommentList", ujetCommentList);

    ujetCommentList.$inject = ["_", "dialogService", "notificationsService", "ujetCommentFactory", "queryService"];

    function ujetCommentList(_, dialogService, notificationsService, ujetCommentFactory, queryService) {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/commentList/commentListView.html",
            scope: {
                ngModel: "="
            },
            link: link
        };

        return directive;

        function link(scope, element, attrs) {
            var dialog;
            var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "EntityId", "AuthorId", "Text"]);

            function runQuery() {
                ujetCommentFactory.query(query.compile(scope.ngModel)).success(function (data) {
                    scope.result =
                    {
                        Columns: query.OrderBy.Options,
                        Rows: data.Objects
                    };

                    scope.paging = {
                        PageIndex: query.PageIndex.Value,
                        PageCount: Math.ceil(data.Total / query.PageSize.Value)
                    };
                });
            };

            scope.$on("pageIndexChanged", function (e, pageIndex) {
                query.PageIndex.Value = pageIndex;

                runQuery();
            });

            scope.$on("selectedRowChanged", function (e, row) {
                if (!_.isNull(dialog)) {
                    dialogService.close(dialog);
                }

                dialog = dialogService.open({
                    template: "/App_Plugins/uJetSocial/backoffice/comment/edit.html",
                    callback: updateObj,
                    dialogData: row
                });
            });

            function updateObj(obj) {
                if (!_.isNull(dialog)) {
                    dialogService.close(dialog);
                }

                ujetCommentFactory.update(obj)
                    .success(function () {
                        notificationsService.success("Comment updated");

                        runQuery();
                    })
                    .error(function () {
                        notificationsService.error("Comment could not be updated");
                    });

                dialog = null;
            }

            runQuery();
        }
    };
})();