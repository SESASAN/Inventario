// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggleSidebar() {
    const sidebar = document.getElementById("sidebar");
    const toggleButton = document.getElementById("sidebar-toggle");

    // Alterna la clase "open" en la barra lateral
    sidebar.classList.toggle("open");

    // Cambia la posición del botón sincronizado con la barra lateral
    if (sidebar.classList.contains("open")) {
        toggleButton.style.left = "270px";
    } else {
        toggleButton.style.left = "20px";
    }
}

