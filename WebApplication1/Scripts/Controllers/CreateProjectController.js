var CreateProjectController = function ($scope, $stateParams, $location, ProjectFactory) {
    $scope.project = {
        name: "",
        returnUrl: $stateParams.returnUrl,
        creationFailure: false
    };

    $scope.create = function () {
        var result = ProjectFactory($scope.project.name);
        result.then(function (result) {
            console.log(result.success);
            if (result.success) {
                if ($scope.project.returnUrl !== undefined) {
                    $location.path('/routeOne');
                } else {
                    $location.path($scope.project.returnUrl);
                }
            } else {
                console.log("hey");
                $scope.project.creationFailure = true;
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

CreateProjectController.$inject = ['$scope', '$stateParams', '$location', 'ProjectFactory'];