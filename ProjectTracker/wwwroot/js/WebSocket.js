var Ws = {};

Ws.uri = "wss://" + window.location.host + "/notifications";

Ws.connect = function () {
    socket = new WebSocket(Ws.uri);

    socket.onopen = function (event) {
        console.log("opened connection to " + Ws.uri);
        $.ajax({
            url: "https://" + window.location.host + "/api/ProjectLobby/InitialMessageAsync",
            method: 'GET'
        });
    };

    socket.onclose = function (event) {
        console.log("closed connection from " + Ws.uri);
    };

    socket.onmessage = function (event) {
        try {
            var message = JSON.parse(event.data);
            if (message.Type == "ListUpdate") {
                console.log("confirmed as listupdate")
                Lobby.projectListMessage(message.Data)
            }
            else if (message.Type == "ChatMessage") {
                Lobby.newChatMessage(message.Data)
            }
            console.log("Parsing", message)
        }
        catch (err) {
            console.log("couldn't parse", event.data)

        }
        //Lobby.newChatMessage(event.data);
        //console.log(event.data);
    };

    socket.onerror = function (event) {
        console.log("error: " + event.data);
    };
}
Ws.connect();