(function () {
    "use strict";

    angular
        .module("umbraco.directives")
        .directive("ujetGuestList", ujetGuestList);

    ujetGuestList.$inject = ["_", "dialogService", "notificationsService", "ujetGuestFactory", "queryService"];

    function ujetGuestList(_, dialogService, notificationsService, ujetGuestFactory, queryService) {
        var directive = {
            restrict: "E",
            templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/guestList/guestListView.html",
            scope: {
                ngModel: "="
            },
            link: link
        };

        return directive;

        function link(scope, element, attrs) {
            var dialog;
            var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "FirstName", "LastName"]);

            function runQuery() {
                ujetGuestFactory.query(query.compile(scope.ngModel)).success(function (data) {
                    scope.result =
                    {
                        columns: query.orderBy.options,
                        rows: data.objects
                    };

                    scope.paging = {
                        pageIndex: query.pageIndex.value,
                        pageCount: Math.ceil(data.total / query.pageSize.value)
                    };
                });
            };

            scope.$on("pageIndexChanged", function (e, pageIndex) {
                query.pageIndex.value = pageIndex;

                runQuery();
            });

            scope.$on("selectedRowChanged", function (e, row) {
                if (!_.isNull(dialog)) {
                    dialogService.close(dialog);
                }

                dialog = dialogService.open({
                    template: "/App_Plugins/uJetSocial/backoffice/guest/edit.html",
                    callback: updateObj,
                    dialogData: row
                });
            });

            function updateObj(obj) {
                if (!_.isNull(dialog)) {
                    dialogService.close(dialog);
                }

                ujetGuestFactory.update(obj)
                    .success(function () {
                        notificationsService.success("Guest updated");

                        runQuery();
                    })
                    .error(function () {
                        notificationsService.error("Guest could not be updated");
                    });

                dialog = null;
            }

            runQuery();
        }
    };
})();