var app = angular.module('ddapp', ['ngRoute', 'ngAnimate'])
.config(['$routeProvider', '$locationProvider',
  function ($routeProvider, $locationProvider) {
      $routeProvider
        .when('/', {
            templateUrl: 'Views/Home.html',
            controller: 'homecontroller' ,          
            controllerAs: 'vm'
        })
        .when('/Home', {
            templateUrl: 'Views/Home.html',
            controller: 'homecontroller',
            controllerAs: 'vm'
        });
      $locationProvider.html5Mode({
          enabled: true,
          requireBase: false
      });
  }])

