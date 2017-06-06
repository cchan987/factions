var Ws = {};

Ws.uri = "wss://" + window.location.host + "/notifications";

Ws.connect = function () {
    socket = new WebSocket(Ws.uri);

    socket.onopen = function (event) {
        console.log("opened connection to " + Ws.uri);
    };

    socket.onclose = function (event) {
        console.log("closed connection from " + Ws.uri);
    };

    socket.onmessage = function (event) {
        Lobby.newChatMessage(event.data);
        console.log(event.data);
    };

    socket.onerror = function (event) {
        console.log("error: " + event.data);
    };
}
Ws.connect();