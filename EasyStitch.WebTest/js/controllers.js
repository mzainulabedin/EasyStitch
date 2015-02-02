angular.module('easyStitchApp.controllers', []).
controller('colorsController', function ($scope, easyStitchAPIservice) {
    $scope.nameFilter = null;
    $scope.colorsList = [];

    easyStitchAPIservice.getColors()
        .success(function (response) {
            //Dig into the responde to get the relevant data
            $scope.colorsList = response.value;
        })
        .error(function (response) {
            //Dig into the responde to get the relevant data
            //$scope.driversList = response.MRData.StandingsTable.StandingsLists[0].DriverStandings;
        });

    //$scope.colorsList = [
    //  {
    //      name: 'Red',
    //      value: 'ff0000'
    //  },
    //  {
    //      name: 'Blue',
    //      value: '0000ff'
    //  }
    //];
});