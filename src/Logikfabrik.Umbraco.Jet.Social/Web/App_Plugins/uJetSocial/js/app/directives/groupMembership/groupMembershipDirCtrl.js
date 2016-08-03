(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupMembershipDirCtrl", ujetGroupMembershipDirCtrl);

    ujetGroupMembershipDirCtrl.$inject = ["$scope", "notificationsService", "localService", "queryService", "ujetGroupMembershipFactory"];

    function ujetGroupMembershipDirCtrl($scope, notificationsService, localService, queryService, ujetGroupMembershipFactory) {
        var vm = {
            memberId: null,
            groupId: null,
            hasObjects: false,
            add: add,
            config: {
                local: localService.localize({
                    errorCategoryAddMembership: "",
                    addMembershipError: "",
                    addMembershipDuplicateError: ""
                })
            }
        };

        $scope.vm = vm;

        var query = queryService.getQuery();

        query.pageSize.value = 1; //10;

        function add() {
            var q = {
                GroupId: vm.groupId,
                MemberId: vm.memberId
            };

            ujetGroupMembershipFactory.query(query.compile(q))
                .then(function (response) {
                    if (response.data.objects.length !== 0) {
                        notificationsService.error(vm.config.local.errorCategoryAddMembership, vm.config.local.addMembershipDuplicateError);

                        return;
                    }

                    ujetGroupMembershipFactory.add({
                            GroupId: vm.groupId,
                            MemberId: vm.memberId
                        })
                        .then(function() {
                            search();
                        }, function () {
                            notificationsService.error(vm.config.local.errorCategoryAddMembership, vm.config.local.addMembershipError);
                        });
                });
        }

        function search() {
            var q = {
                GroupId: vm.groupId
            };

            ujetGroupMembershipFactory.query(query.compile(q))
                .then(function(response) {
                    vm.objects = response.data.objects;

                    vm.paging = {
                        pageIndex: query.pageIndex.value,
                        pageCount: Math.ceil(response.data.total / query.pageSize.value)
                    };

                    vm.hasObjects = vm.objects.length > 0;
                });
        };

        $scope.$on("deleteObject", function (e, object) {
            ujetGroupMembershipFactory.remove(object.id)
                .then(function() {
                    search();
                });
        });

        $scope.$on("pageIndexChanged", function (e, pageIndex) {
            query.pageIndex.value = pageIndex;

            search();
        });

        $scope.$watch("model", function (newValue) {
            if (_.isNull(newValue) ||
                _.isUndefined(newValue) ||
                _.isNaN(newValue)) {

                vm.groupId = null;
                vm.memberId = null;
                vm.hasObjects = false;

                return;
            }

            vm.groupId = newValue;
            vm.memberId = null;

            search();
        });
    };
})();