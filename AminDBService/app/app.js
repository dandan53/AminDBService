var app = angular.module("TodoApp", ["ngResource", "ngRoute", "ngStorage"]);

app.config(function ($routeProvider) {
    $routeProvider.
         when('/', { controller: 'MainCtrl', templateUrl: 'app/main/main.html' }).
         when('/list', { controller: 'ListCtrl', templateUrl: 'app/list/list.html' }).
         when('/newperson', { controller: 'NewPersonCtrl', templateUrl: 'app/newperson/newperson.html' }).
         otherwise({ redirectTo: '/' });
});