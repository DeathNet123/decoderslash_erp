// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
toggle_theme = () => {
    themes = {
        "light": "dark",
        "dark": "light"
    };
    let root = document.documentElement;
    root.setAttribute("data-bs-theme", themes[root.getAttribute("data-bs-theme")]);
}