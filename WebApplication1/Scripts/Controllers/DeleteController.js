var DeleteController = function ($scope, $stateParams, $location, DeletionFactory) {
    $scope.element = {
        name: "",
        returnUrl: $stateParams.returnUrl,
        deletionFailure: false
    };

    $scope.delete = function () {
        var result = DeletionFactory($scope.element.name);
        result.then(function (result) {
            if (result.success) {
                if ($scope.element.returnUrl !== undefined) {
                    $location.path('/routeOne');
                } else {
                    $location.path($scope.element.returnUrl);
                }
            } else {
                $scope.element.deletionFailure = true;
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

DeleteController.$inject = ['$scope', '$stateParams', '$location', 'DeletionFactory'];