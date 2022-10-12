// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

LOGIN = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#LOGIN .modal-body").html(res);
            $("#LOGIN .modal-title").html(title);
            $("#LOGIN").modal('show');
        }
    })
}
