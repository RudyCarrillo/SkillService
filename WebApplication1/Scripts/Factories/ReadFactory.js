var ReadFactory = function ($http, $q) {
    return function (name) {

        var deferredObject = $q.defer();

        $http.get(
            '/routesDemo/ReadResult/' + name
        ).
        success(function (data) {
            //console.log(data);
            //if (data == "True") {
                deferredObject.resolve(data);
            //} else {
            //    console.log("error");
            //    deferredObject.resolve({ success: false });
            //}
        }).
        error(function () {
            deferredObject.reject(err);
        });
        return deferredObject.promise;
    }
}

ReadFactory.$inject = ['$http', '$q'];