//file for displaying map and directions using the google maps and directions API

let toLat = parseFloat(document.getElementById('toLat').value);
let toLong = parseFloat(document.getElementById('toLong').value);
let fromLat = parseFloat(document.getElementById('fromLat').value);
let fromLong = parseFloat(document.getElementById('fromLong').value);

let map;


//function for displaying map and displaying directions on top of the map
async function initMap() {
    //@ts-ignore
    const { Map } = await google.maps.importLibrary("maps");

    map = new Map(document.getElementById("map"), {
        center: { lat: toLat, lng: toLong },
        zoom: 16,
    });
    
    const directionsService = new google.maps.DirectionsService();
    const directionsRenderer = new google.maps.DirectionsRenderer({
        draggable: false,
        map,
    });

    let originPoint = {
        lat: fromLat,
        lng: fromLong
    }

    let destPoint = {
        lat: toLat,
        lng: toLong
    }

    displayRoute(originPoint, destPoint, directionsService, directionsRenderer);
    
}

//function for displaying route 
function displayRoute(origin, destination, service, display) {
    //call to google API for displaying the best walking route from one point to the next 
    service.route({
        origin: origin,
        destination: destination,
        travelMode: google.maps.TravelMode.WALKING,
    })
        .then((result) => {
            display.setDirections(result);
        })
        .catch((e) => {
            alert("could not display directions due to: " + e);
        }
    );
}


initMap();