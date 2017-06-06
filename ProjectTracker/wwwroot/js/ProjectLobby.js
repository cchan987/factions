

var list = document.getElementById("messages");
var input = document.getElementById("textInput");

input.addEventListener("keypress", function (e) {
    var key = e.which || e.keyCode;
    if (key === 13) {
        var input = document.getElementById("textInput");
        sendMessage(input.value);

        input.value = "";
    }
});

function sendMessage(message) {
    console.log("Sending: " + message);
    if (message.length == 0) {
        return;
    }
    $.ajax({
        url: "https://" + window.location.host + "/api/socketmessages/sendmessage?message=" + message,
        method: 'GET'
    });
}