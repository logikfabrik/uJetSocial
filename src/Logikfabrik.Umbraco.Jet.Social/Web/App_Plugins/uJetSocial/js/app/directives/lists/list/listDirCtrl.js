(function () {
    "use strict";

    angular
        .module("umbraco")
        .controller("ujetListDirCtrl", ujetListDirCtrl);

    ujetListDirCtrl.$inject = ["$scope", "_"];

    function ujetListDirCtrl($scope, _) {
        var vm = {
            sortColumn: null,
            sortAscending: true,
            sort: sort,
            select: select,
            getCellValue: getCellValue
        };

        $scope.vm = vm;
        $scope._ = _;

        function sort(column) {
            vm.sortAscending = (vm.sortColumn === column) ? !vm.sortAscending : true;
            vm.sortColumn = column;

            vm.rows = _.sortBy(vm.rows, [column]).reverse();
        };

        function select(row) {
            $scope.$emit("selectedRowChanged", row);
        };

        function getCellValue(row, column) {
            var propertyName = column.substr(0, 1).toLowerCase() + column.substr(1);

            return _.property(propertyName)(row);
        };

        $scope.$watch("model", function (newValue) {
            if (!_.isObject(newValue)) {
                return;
            }

            vm.columns = newValue.columns;
            vm.rows = newValue.rows;
        });
    };
})();