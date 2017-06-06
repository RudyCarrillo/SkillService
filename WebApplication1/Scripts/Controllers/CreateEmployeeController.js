var CreateEmployeeController = function ($scope, $stateParams, $location, EmployeeFactory) {
    $scope.employee = {
        name: "",
        returnUrl: $stateParams.returnUrl,
        creationFailure: false
    };

    $scope.create = function () {
        var result = EmployeeFactory($scope.employee.name);
        result.then(function (result) {
            if (result.success) {
                if ($scope.employee.returnUrl !== undefined) {
                    $location.path('/routeOne');
                } else {

                    $location.path($scope.employee.returnUrl);
                }
            } else {
                $scope.employee.creationFailure = true;
            }

            $scope.enableButton();
        });
    }

    $scope.disableButton = function () {
        $scope.isDisabled = true;
    }

    $scope.enableButton = function () {
        $scope.isDisabled = false;
    }
}

CreateEmployeeController.$inject = ['$scope', '$stateParams', '$location', 'EmployeeFactory'];