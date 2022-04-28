// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('.navbar-nav').find('a').each(function () {
        $(this).click(function (e) {
            $(this).addClass('active');
            $(this).parent().siblings().children().removeClass('active');
            //e.preventDefault();
        })
    })
});