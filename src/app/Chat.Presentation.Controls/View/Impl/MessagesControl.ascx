<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessagesControl.ascx.cs"
    Inherits="Chat.Presentation.Controls.View.Impl.MessagesControl" %>
<div align="center" class="receivePanel">
    <textarea id="receiveMessages" style="width: 600px; height: 300px; overflow: scroll"
        readonly="readonly"></textarea>
    <br />
    <br />
    <input type="hidden" id="userId" value="<%= Session["userId"] as string%>" />
    <input type="hidden" id="userRole" value="<%= Session["userRole"] as string%>" />
    <input type="hidden" id="roomId" value="<%= RoomId%>" />
    
    <div id="sendPanel">
        <input type="text" id='sendTB' textmode="MultiLine" style="height: 61px; width: 500px;" />
        <input type="button" onclick="user.Send()" id="button" value="Send" style="width: 50px;
            height: 50px" />
    </div>
</div>
<script type="text/javascript">

    function User() {
    }

    User.prototype.Role = document.getElementById('userRole');
    User.prototype.CurentRoomId = document.getElementById('roomId');
    User.prototype.MessageToSend = document.getElementById('sendTB');
    User.prototype.UserId = document.getElementById('userId');

    User.prototype.Get = function () {
        var url = "http://localhost:52500/Services/MessageService.svc/ReceiveMessages";
        var jData = {};
        jData.userId = this.UserId.value;
        jData.chatRoomId = this.CurentRoomId.value;
        var stringData = JSON.stringify(jData);
        JsonGet(url, stringData);
    };

    User.prototype.Send = function () {
        if (this.Role.value == 0) {
            alert("You should login to send message!");
            return;
        }

        if (this.MessageToSend.value != "") {
            var url = "http://localhost:52500/Services/MessageService.svc/SendMessage";
            var jData = {};
            jData.text = this.MessageToSend.value;
            this.MessageToSend.value = "";
            jData.userId = this.UserId.value;
            jData.chatRoomId = this.CurentRoomId.value;
            var stringData = JSON.stringify(jData);
            JsonPost(url, stringData);
        }
        else
            alert("Would you please enter some text?");
    };

    var user = new User();

    shortcut.add("ctrl+enter", function () {
        user.Send();
    });

    setInterval("user.Get()", 1000);
        
</script>
