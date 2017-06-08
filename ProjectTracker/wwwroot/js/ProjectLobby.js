

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
    
    if (message === undefined || message.length === 0) {
        console.log("Didn't send: " + message);
        return;
    }

    console.log("Sending: " + message);
    $.ajax({
        url: "https://" + window.location.host + "/api/socketmessages/sendmessage?message=" + message,
        method: 'GET'
    });
}