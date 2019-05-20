// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $('ul.nav li.dropdown').hover(
        function () { $('.dropdown-menu', this).slideDown(); },
        function () { $('.dropdown-menu', this).slideUp('fast'); }
    )
})