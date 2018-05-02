/// <reference path="angular.js" />

var draftBoardApp = angular
    .module("draftBoardApp", [])
    .controller("draftBoardAppController", function ($scope, $http) {
        $http.get("PlayerService.asmx/GetPlayers")
            .then(function (response) {
                $scope.players = response.data;
            });
    });