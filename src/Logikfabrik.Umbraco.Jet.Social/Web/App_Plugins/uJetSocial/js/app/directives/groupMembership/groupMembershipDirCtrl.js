(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetGroupMembershipDirCtrl", ujetGroupMembershipDirCtrl);

    ujetGroupMembershipDirCtrl.$inject = ["$scope", "queryService", "ujetGroupMembershipFactory"];

    function ujetGroupMembershipDirCtrl($scope, queryService, ujetGroupMembershipFactory) {
        var vm = {
            memberId: null,
            groupId: null,
            hasObjects: false,
            add: add
        };
        
        $scope.vm = vm;

        var query = queryService.getQuery();

        query.pageSize.value = 5;
        
        function add() {
            ujetGroupMembershipFactory.add({
                GroupId: vm.groupId,
                MemberId: vm.memberId
            });

            search();
        }

        function search() {
            var q = {
                GroupId: vm.groupId
            };

            ujetGroupMembershipFactory.query(query.compile(q)).success(function (data) {
                vm.objects = data.objects;

                vm.paging = {
                    pageIndex: query.pageIndex.value,
                    pageCount: Math.ceil(data.total / query.pageSize.value)
                };

                vm.hasObjects = vm.objects.length > 0;
            });
        };

        $scope.$on("deleteObject", function (e, object) {
            ujetGroupMembershipFactory.remove(object.id);

            search();
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