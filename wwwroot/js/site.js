// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#samsIdInput").keypress(function () {
    $.get('/UserCases/FindCases', $("#samsIdInput").val(), function (data) {
        console.log(data);
    });
});
