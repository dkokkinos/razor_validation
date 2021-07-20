// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$.validator.addMethod('uppercase', function (value, element, params) {
    let startingUpperCaseCharacters = parseInt(params);
    if (value.length < startingUpperCaseCharacters)
        return false;

    return value.substring(0, startingUpperCaseCharacters) === value.substring(0, startingUpperCaseCharacters).toUpperCase();
});

$.validator.unobtrusive.adapters.addSingleVal("uppercase", "startingUpperCaseCharacters");