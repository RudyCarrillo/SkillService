var EmployeesSkillsApp = angular.module('EmployeesSkillsApp', ['ui.router', 'ui.bootstrap']);

EmployeesSkillsApp.controller('LandingPageController', LandingPageController);
EmployeesSkillsApp.controller('LoginController', LoginController);
EmployeesSkillsApp.controller('RegisterController', RegisterController);
EmployeesSkillsApp.controller('CreateProjectController', CreateProjectController);
EmployeesSkillsApp.controller('CreateEmployeeController', CreateEmployeeController);
EmployeesSkillsApp.controller('CreateSkillController', CreateSkillController);
EmployeesSkillsApp.controller('ReadController', ReadController);
EmployeesSkillsApp.controller('UpdateController', UpdateController);
EmployeesSkillsApp.controller('DeleteController', DeleteController);
EmployeesSkillsApp.factory('LoginFactory', LoginFactory);
EmployeesSkillsApp.factory('RegistrationFactory', RegistrationFactory);
EmployeesSkillsApp.factory('ProjectFactory', ProjectFactory);
EmployeesSkillsApp.factory('EmployeeFactory', EmployeeFactory);
EmployeesSkillsApp.factory('SkillFactory', SkillFactory);
EmployeesSkillsApp.factory('ReadFactory', ReadFactory);
EmployeesSkillsApp.factory('UpdateFactory', UpdateFactory);
EmployeesSkillsApp.factory('DeletionFactory', DeletionFactory);
EmployeesSkillsApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
EmployeesSkillsApp.factory('ReadAndUpdate', function () {
    return { name: '' };
});

var configFunction = function ($stateProvider, $httpProvider, $locationProvider) {

    $locationProvider.hashPrefix('!').html5Mode(true);

    $stateProvider
        .state('stateOne', {
            url: '/stateOne?donuts',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/One'
                },
                "containerTwo": {
                    templateUrl: function (params) { return '/routesDemo/Two?donuts=' + params.donuts; }
                }
                ,
                "nestedView@stateOne": {
                    templateUrl: '/routesDemo/four'
                }
            }
        })
        .state('stateTwo', {
            url: '/stateTwo',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/One'
                },
                "containerTwo": {
                    templateUrl: '/routesDemo/Three'
                }
            }
        })
        .state('stateThree', {
            url: '/stateThree?donuts',
            views: {
                "containerOne": {
                    templateUrl: function (params) { return '/routesDemo/two?donuts=' + params.donuts; }
                },
                "containerTwo": {
                    templateUrl: '/routesDemo/One'
                }
            }
        })
        .state('loginRegister', {
            url: '/loginRegister?returnUrl',
            views: {
                "containerOne": {
                    templateUrl: '/Account/Login',
                    controller: LoginController
                },
                "containerTwo": {
                    templateUrl: '/Account/Register',
                    controller: RegisterController
                }
            }
        })
        .state('stateCreateProject', {
            url: '/createProject',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/CreateProject',
                    controller: CreateProjectController
                }
            }
        })
        .state('stateCreateEmployee', {
            url: '/createEmployee',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/CreateEmployee',
                    controller: CreateEmployeeController
                }
            }
        })
        .state('stateCreateSkill', {
            url: '/createSkill',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/CreateSkill',
                    controller: CreateSkillController
                }
            }
        })
        .state('stateRead', {
            url: '/read',
            views: {
                "containerOne": {
                    templateUrl: 'routesDemo/Read',
                    controller: ReadController
                }
            }
        })
        .state('stateUpdate', {
            url: '/update',
            views: {
                "containerOne": {
                    templateUrl: 'routesDemo/Update',
                    controller: UpdateController
                }
            }
        })
        .state('stateDelete', {
            url: '/delete',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/Delete',
                    controller: DeleteController
                }
            }
        });

        //.state('stateCreateEmployee', {
        //    url: '/createEmployee',
        //    views: {
        //        "containerOne": {
        //            templateUrl: '/RoutesDemo/CreateEmployee',
        //            controller: CreateEmployeeController
        //        }
        //    }
        //})
        //.state('stateCreateSkill', {
        //    url: '/createSkill',
        //    views: {
        //        "containerOne": {
        //            templateUrl: '/RoutesDemo/CreateSkill',
        //            controller: CreateSkillController
        //        }
        //    }
        //});

    //$routeProvider
    //    .when('/createProject', {
    //        templateUrl: 'routesDemo/CreateProject',
    //        controller: CreateProjectController
    //    })
    //    .when('/createEmployee', {
    //        templateUrl: 'routesDemo/CreateEmployee',
    //        controller: CreateEmployeeController
    //    })
    //    .when('/createSkill', {
    //        templateUrl: 'routesDemo/CreateSkill',
    //        controller: CreateSkillController
    //    })
    //    .when('/read', {
    //        templateUrl: 'routesDemo/Read',
    //        controller: ReadController
    //    })
    //    .when('/update', {
    //        templateUrl: 'routesDemo/Update',
    //        controller: UpdateController
    //    })
    //    .when('/delete', {
    //        templateUrl: 'routesDemo/Delete',
    //        controller: DeleteController
    //    });

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$stateProvider', '$httpProvider', '$locationProvider'];

EmployeesSkillsApp.config(configFunction);