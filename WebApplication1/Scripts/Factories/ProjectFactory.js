var ProjectFactory = function ($http, $q) {
    return function (name) {

        var deferredObject = $q.defer();

        $http.post(
            '/routesDemo/ProjectResult', {
                Name: name
            }
        ).
        success(function (data) {
            console.log(data);
            if (data == "True") {
                deferredObject.resolve({ success: true });
            } else {
                console.log("error");
                deferredObject.resolve({ success: false });
            }
        }).
        error(function () {
            deferredObject.resolve({ success: false });
        });
        return deferredObject.promise;
    }
}

ProjectFactory.$inject = ['$http', '$q'];