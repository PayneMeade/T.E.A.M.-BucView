// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
if (window.location.toString().indexOf("Tour") != -1) {
    document.addEventListener('keypress', function (e) {
        if (e.key == 'Enter') {
            document.getElementById('nextButton').click();
        }
    });
}
if (window.location.toString().indexOf("Directions") != -1) {
    document.addEventListener('keypress', function (e) {
        if (e.key == 'Enter') {
            document.getElementById('foundIt').click();
        }
    })
    var lat = document.getElementById('lat').value;
    var long = document.getElementById('long').value;
}




var map = L.map('map', {
    center: [lat, long],
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

var marker = L.marker([lat, long]);

// Adding marker to the map
marker.addTo(map);

