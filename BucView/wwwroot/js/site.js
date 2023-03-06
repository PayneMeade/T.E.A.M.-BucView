// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var map = L.map('map', {
    center: [36.3024, -82.3699],
    zoom: 17,
    maxZoom: 19,
    minZoom: 15,
    maxBoundsViscosity: 0.5,
    maxBounds: L.latLngBounds([36.309700, -82.362047], [36.296604, -82.376253])
});

L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">Open Street Maps</a>'
}).addTo(map);
