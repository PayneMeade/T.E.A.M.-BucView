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

//api key: 

let lat = parseFloat(document.getElementById('toLat').value);
let long = parseFloat(document.getElementById('toLong').value);
let toBuilding = document.getElementById('toBuilding').value;
//console.log("Lat", lat);
//console.log("Long", long);

//this function uses the Haversine formula
//this formula calculates the shortest distance between two points on the Earth
//(or a sphere in general)
//https://community.esri.com/t5/coordinate-reference-systems-blog/distance-on-a-sphere-the-haversine-formula/ba-p/902128
const distanceToBuilding = (userLat, userLong, buildingLat, buildingLong) => {
    const R = 6.371e6 //the Earth's mean radius in meters

    //convert to radians
    let phi1 = userLat * Math.PI / 180;
    let phi2 = buildingLat * Math.PI / 180;

    //difference in longitude and latitude in radians
    let delta_phi = (buildingLat - userLat) * Math.PI / 180;
    let delta_lambda = (buildingLong - userLong) * Math.PI / 180;

    //haversine formula
    let a = Math.pow(Math.sin(delta_phi / 2), 2)
        + Math.cos(phi1) * Math.cos(phi2)
        * Math.pow(Math.sin(delta_lambda / 2), 2);

    //central angle (angle between the two points relative to the Earth's center) in radians
    let c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));

    let d = R * c; //distance in meters (arc length of the central angle)

    return d;
}

const positionCallback = (position) => {
    let userLat = position.coords.latitude;
    let userLong = position.coords.longitude;
    if (distanceToBuilding(userLat, userLong, lat, long) <= 15)
        window.location.href = encodeURI(`../../Tour/Index/${toBuilding}`);
}

const errorCallback = (error) => {
    console.log(error);
}

const getLocation = () => {
    navigator.geolocation.getCurrentPosition(positionCallback, errorCallback, { enableHighAccuracy: true });
}

getLocation();