var UpdateController = function ($scope, $stateParams, $location, UpdateFactory, ReadAndUpdate) {
    $scope.parentToAdd = {
        name: "",
        returnUrl: $stateParams.returnUrl,
        updatingFailure: false
    };

    $scope.update = function () {
        var result = UpdateFactory($scope.toUpdate.name, $scope.parentToAdd.name);
        result.then(function (result) {
            if (result.success) {
                if ($scope.parentToAdd.returnUrl !== undefined) {
                    $location.path('/routeOne');
                } else {
                    $location.path($scope.parentToAdd.returnUrl);
                }
            } else {
                $scope.parentToAdd.updatingFailure = true;
            }
        });
    }

    $scope.toUpdate = ReadAndUpdate;
}

UpdateController.$inject = ['$scope', '$stateParams', '$location', 'UpdateFactory', 'ReadAndUpdate'];