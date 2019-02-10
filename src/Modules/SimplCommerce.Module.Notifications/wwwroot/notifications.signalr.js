/*global $ */
$(function () {
    "use strict";
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalr").build();
    connection.on('getNotification', function (notification) {
        console.info(notification);
        alert(notification.detail.data.message);
    });
    connection.start().catch(function (err) {
        return console.error(err.toString());
    });
});
