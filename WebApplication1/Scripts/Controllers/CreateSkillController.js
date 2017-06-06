var CreateSkillController = function ($scope, $stateParams, $location, SkillFactory) {
    $scope.skill = {
        name: "",
        returnUrl: $stateParams.returnUrl,
        creationFailure: false
    };

    $scope.create = function () {
        var result = SkillFactory($scope.skill.name);
        result.then(function (result) {
            if (result.success) {
                if ($scope.skill.returnUrl !== undefined) {
                    $location.path('/routeOne');
                } else {

                    $location.path($scope.skill.returnUrl);
                }
            } else {
                $scope.skill.creationFailure = true;
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

CreateSkillController.$inject = ['$scope', '$stateParams', '$location', 'SkillFactory'];