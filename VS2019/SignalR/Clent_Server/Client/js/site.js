var connection = new signalR.HubConnectionBuilder()
.withUrl("http://localhost:64158/chatHub/")
.build();

connection.start();

connection.on("ReceiveMessage", (fromUser, message) => {
 const li = document.createElement("li");
 li.textContent = fromUser + " : " + message;
 document.getElementById("messagesList").appendChild(li);
});

document.getElementById("sendButton").addEventListener("click", event => {
 const user = document.getElementById("userInput").value;
 const message = document.getElementById("messageInput").value;
 connection.invoke("SandMessage", user, message)
 .catch(err => console.error(err.toString()));
 event.preventDefault();
});

