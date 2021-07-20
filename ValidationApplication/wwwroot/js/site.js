// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$.validator.addMethod('uppercase', function (value, element, params) {
    return value === value.toUpperCase();
});

$.validator.unobtrusive.adapters.addBool("uppercase");