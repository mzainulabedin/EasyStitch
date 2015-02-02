﻿'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers', [])

    // Path: /
    .controller('HomeCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA Template for Visual Studio';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /colors
    .controller('ColorsCtrl', ['$scope', '$location', '$window', '$http', function ($scope, $location, $window, $http) {
        $scope.$root.title = 'AngularJS SPA | Colors';

        $scope.getColorList = function () {
            $http.get('http://localhost:50000/odata/colors')
                .success(function (data, status, headers, config) {
                    $scope.$root.title = $scope.$root.title + " - Success";
                    $scope.$root.colors = data.value;
                    $scope.colorName = 'REd';
                    $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title, 'colorName': 'Blue' });
                })
                .error(function (data, status, headers, config) {
                    $scope.colorName = 'Yellow';
                    $scope.$root.title = $scope.$root.title + " - Error";
                    $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title, 'colorName': 'Black' });
                });
        };

        $scope.$on('$viewContentLoaded', function () {
            $scope.getColorList();
            
        });
    }])

    // Path: /about
    .controller('AboutCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA | About';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /login
    .controller('LoginCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA | Sign In';
        // TODO: Authorize a user
        $scope.login = function () {
            $location.path('/');
            return false;
        };
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /error/404
    .controller('Error404Ctrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Error 404: Page Not Found';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }]);