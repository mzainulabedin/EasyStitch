angular.module('easyStitchApp.services', []).
  factory('easyStitchAPIservice', function ($http) {

      var easyStitchAPI = {};

      easyStitchAPI.getColors = function () {
          return $http({
              method: 'JSONP',
              url: 'http://localhost:50000/odata/colors'
          });
      }

      return easyStitchAPI;
  });