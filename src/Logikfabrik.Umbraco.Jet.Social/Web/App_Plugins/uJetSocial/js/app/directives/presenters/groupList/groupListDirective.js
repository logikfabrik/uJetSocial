(function () {
    'use strict';

    angular
        .module("umbraco.directives")
        .directive("ujetGroupList", ujetGroupList);

    ujetGroupList.$inject = ["_", "dialogService", "notificationsService", "ujetGroupFactory", "queryService"];

    function ujetGroupList(_, dialogService, notificationsService, ujetGroupFactory, queryService) {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/groupList/groupListView.html",
            scope: {
                ngModel: "="
            },
            link: link
        };

        return directive;

        function link(scope, element, attrs) {
            var dialog;
            var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "Name", "Description", "OwnerId"]);

            function runQuery() {
                ujetGroupFactory.query(query.compile(scope.ngModel)).success(function (data) {
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
                    template: "/App_Plugins/uJetSocial/backoffice/group/edit.html",
                    callback: updateObj,
                    dialogData: row
                });
            });

            function updateObj(obj) {
                if (!_.isNull(dialog)) {
                    dialogService.close(dialog);
                }

                ujetGroupFactory.update(obj)
                    .success(function () {
                        notificationsService.success("Group updated");

                        runQuery();
                    })
                    .error(function () {
                        notificationsService.error("Group could not be updated");
                    });

                dialog = null;
            }

            runQuery();
        }
    };
})();