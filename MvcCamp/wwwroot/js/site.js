// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function loadContent(headingId) {
    $.ajax({
        url: '/Default/Index', // Adjust the URL if needed
        type: 'GET',
        data: { id: headingId },
        success: function (data) {
            $('#dynamicContent').html(data);
        },
        error: function () {
            alert('Error loading content.');
        }
    });
}