var readUrl = '@Url.Action("MarkNotificationAsRead")';
var deleteUrl = '@Url.Action("Delete")';
var currentNotificationId;

function updateNotification(id, action) {
    $("#notificationFormItemId").val(id);
    switch (action) {
        case 'read':
            $("#notificationForm").attr('action', readUrl).submit();
            break;
        case 'delete':
            $("#notificationForm").attr('action', deleteUrl).submit();
            break;
        default:
            console.debug('Unknown action ' + action);
    }
}

function confirmDelete(id) {
    currentNotificationId = id;
    $('#deleteConfirmModal').modal('show');
}

$(function () {
    $("#deleteConfirmModal").on('click', "#deleteConfirm", function () {
        updateNotification(currentNotificationId, 'delete');
    });
});
