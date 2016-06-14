(function () {
    "use strict";

    // ReSharper disable once UndeclaredGlobalVariableUsing
    angular
        .module("umbraco")
        .controller("ujetListDirCtrl", ujetListDirCtrl);

    ujetListDirCtrl.$inject = ["$scope", "_", "sprintf"];

    function ujetListDirCtrl($scope, _, sprintf) {
        var vm = {
            sortColumn: null,
            sortAscending: true,
            sort: sort,
            selectedRow: null,
            select: select,
            getCellValue: getCellValue,
            getColumnLangKey: getColumnLangKey
        };

        $scope.vm = vm;
        $scope._ = _;

        function sort(column) {
            vm.sortAscending = (vm.sortColumn === column) ? !vm.sortAscending : true;
            vm.sortColumn = column;

            vm.rows = _.sortBy(vm.rows, [column]).reverse();
        };

        function select(row) {
            vm.selectedRow = row;

            $scope.$emit("selectedRowChanged", row);
        };

        function getCellValue(row, column) {
            var propertyName = column.substr(0, 1).toLowerCase() + column.substr(1);

            return _.property(propertyName)(row);
        };

        function getColumnLangKey(column) {
            /*
             * The localize directive is case-sensitive. Property names (the columns) are feed into the list directive
             * in .NET case (e.g. FirstName, Id, and so on). Lang keys built using this case will not match the entries
             * in the lang files. And changing the case in the lang files would break the naming convention.
             * We therefore build the lang keys, changing the case of the first letter in each column/property name.
             */
            column = column.charAt(0).toLowerCase() + column.slice(1);

            return sprintf("uJetSocial_%sProp", column);
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