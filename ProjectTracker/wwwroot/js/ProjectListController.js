var Lobby = {};

Lobby.app = angular.module('ProjectLobby', []);

Lobby.app.controller('ProjectList', function ($scope) {
    $scope.firstname = "John";
    $scope.lastname = "Doe";
    $scope.ParticipatingIn = [];
    $scope.InProgress = [{ name: "Test InProgress hardcode in angular controller", Id: 10 }];
    $scope.AcceptingParticipants = [{name:"Test AcceptingParticiapnts hardcode in angular controller", Id: 10}];
    $scope.PL = [1, 4, 78];
});

Lobby.app.controller('ChatArea', function ($scope) {
    $scope.messages = [];
    $scope.textValue = ""
    $scope.sendButton = function () {
        sendMessage($scope.textValue);
        $scope.textValue = "";
    }
});

Lobby.newChatMessage = function (message) {
    var scope = angular.element($("#messages")).scope();
    scope.$apply(function () {
        scope.messages.unshift({ name: message});
        if (scope.messages.length > 10) {
            scope.messages.splice(-1, 1)
        }
    });
}

Lobby.projectListMessage = function (projectObject) {
    var project = projectObject.Project;
    if (projectObject.Status == "ParticipatingIn") {
        var scope = angular.element($("#ParticipatingIn")).scope();
        scope.$apply(function () {
            scope.ParticipatingIn.push({ name: project.Name, Id: project.Id });
        });
    }
    else if (projectObject.Status == "InProgress") {
        var scope = angular.element($("#InProgress")).scope();
        scope.$apply(function () {
            scope.InProgress.push({ name: project.Name, Id: project.Id });
        });
    }
    else if (projectObject.Status == "AcceptingParticipants") {
        var scope = angular.element($("#AcceptingParticipants")).scope();
        scope.$apply(function () {
            scope.AcceptingParticipants.push({ name: project.Name, Id: project.Id });
        });
    }

}

