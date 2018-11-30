function ShowEntityModal(result) {
    if (result) {
        if (result.responseJSON) {
            if (result.responseJSON.Status === "Failed") {
                buildMessageContainer(false, result.responseJSON.Message);
                return;
            }
        }
    }
    // reInitializeScripts();
    //$('#divMessage').hide();
    $('#entityModal').modal('show');
    $("#Add").attr('data-toggle', 'modal');
    $("form").removeData("validator");
    $(".modal-body").animate({
        scrollTop: 0
    });
    //$(".modal").draggable({
    //    handle: ".modal-header"
    //});
    //return false;
}



function EditGet() {
    $.ajax({
        url: 'http://localhost:57203/api/ApiTopicOptionMapping/',
        type: "GET",
        dataType: 'json',
        data: { id: 3 },
        success: function (data) {
            $("#entityModal").html(data);
            $('#entityModal').modal('show');
        }
    });
}

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));


}