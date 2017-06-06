var UpdateFactory = function ($http, $q) {
    return function (name, parent) {

        var deferredObject = $q.defer();

        $http.put(
            '/RoutesDemo/UpdateResult', {
                Name: name,
                Parent: parent
            }
        ).
        success(function (data) {
            if (data == "True") {
                deferredObject.resolve({ success: true });
            } else {
                deferredObject.resolve({ success: false });
            }
        }).
        error(function () {
            deferredObject.resolve({ success: false });
        });

        return deferredObject.promise;
    }
}

UpdateFactory.$inject = ['$http', '$q'];