var ReadController = function ($scope, $stateParams, $location, ReadFactory, ReadAndUpdate) {
    $scope.element = {
        name: "",
        returnUrl: $stateParams.returnUrl,
        readFailure: false
    };

    $scope.read = function (ev) {
        if (ev == 'toUpdate') {
            node = $scope.toUpdate;
        } else {
            node = $scope.element;
        }
        var result = ReadFactory(node.name);
        result.then(function (data) {
            console.log(data);
            $scope.result = {
                parents: data
            };
            if ($scope.element.returnUrl !== undefined) {
                $location.path('/routeOne');
            } else {
                $location.path($scope.element.returnUrl);
            }
        }).catch(function(err) {
            console.log("error");
            $scope.element.readFailure = true;
        });
    }

    $scope.toUpdate = ReadAndUpdate;
}

ReadController.$inject = ['$scope', '$stateParams', '$location', 'ReadFactory', 'ReadAndUpdate'];