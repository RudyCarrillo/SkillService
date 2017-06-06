var SkillFactory = function ($http, $q) {
    return function (name) {

        var deferredObject = $q.defer();

        $http.post(
            '/RoutesDemo/SkillResult', {
                Name: name
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

SkillFactory.$inject = ['$http', '$q'];