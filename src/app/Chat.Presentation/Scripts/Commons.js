
function JsonPost(urlToPost, jData) {

    $.ajax({
        cache: false,
        type: "POST",
        async: false,
        url: urlToPost,
        data: jData,
        contentType: "application/json",
        dataType: "json",
        success: function () { 
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}

function JsonGet(urlToPost, jData) {

    $.ajax({
        cache: false,
        type: "POST",
        async: false,
        url: urlToPost,
        data: jData,
        contentType: "application/json",
        dataType: "json",
        success: function (str) {
            var inputTest = document.getElementById("receiveMessages");
            inputTest.value = str;

            inputTest.scrollTop = inputTest.scrollHeight; 
        },
        error: function (xhr) {
                    alert(xhr.responseText);
        }
    });
}
