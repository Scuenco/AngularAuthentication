var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: '/app/Views/Home.html',
        title: 'Home Page'
    }).otherwise({
        redirectTo: '/'
    });
});