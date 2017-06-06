var Lobby = {};

Lobby.app = angular.module('ProjectLobby', []);

Lobby.app.controller('ProjectList', function ($scope) {
    $scope.firstname = "John";
    $scope.lastname = "Doe";
    $scope.ParticipatingIn = ParticipatingIn;
    console.log(ParticipatingIn);
    $scope.PL = [1, 4, 78];
});

Lobby.app.controller('ChatArea', function ($scope) {
    $scope.messages = [];
    $scope.sendButton = function () {
        sendMessage($scope.textValue);
        $("#textInput").val("");
    }
});

Lobby.newChatMessage = function (message) {
    var scope = angular.element($("#messages")).scope();
    scope.$apply(function () {
        scope.messages.push({ name: message });
    });
}