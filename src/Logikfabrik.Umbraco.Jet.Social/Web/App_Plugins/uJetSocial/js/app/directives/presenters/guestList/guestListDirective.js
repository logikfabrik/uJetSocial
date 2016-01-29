angular.module("umbraco.directives")
    .directive("ujetGuestList", [
        "_", "dialogService", "notificationsService", "guestFactory", "queryService",
        function (_, dialogService, notificationsService, guestFactory, queryService) {
            return {
                restrict: "E",
                templateUrl: "/App_Plugins/uJetSocial/js/app/directives/presenters/guestList/guestListView.html",
                scope: {
                    ngModel: "="
                },
                link: function (scope, element, attrs) {

                    var dialog;
                    var query = queryService.getQuery(["Id", "Created", "Updated", "Status", "FirstName", "LastName"]);

                    function runQuery() {
                        guestFactory.query(query.compile(scope.ngModel)).success(function (data) {
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
                            template: "/App_Plugins/uJetSocial/backoffice/guest/edit.html",
                            callback: updateObj,
                            dialogData: row
                        });
                    });

                    function updateObj(obj) {
                        if (!_.isNull(dialog)) {
                            dialogService.close(dialog);
                        }

                        guestFactory.update(obj)
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
        }
    ]);