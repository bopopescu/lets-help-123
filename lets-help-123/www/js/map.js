window.addEventListener('load', initMap);

function initMap() {
    var myLatLng = {lat: 33.7773, lng: -84.3962};
    var map = new google.maps.Map(document.getElementById('map-container-5'), {
        center: myLatLng,
        zoom: 11
    });

    var marker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        title: 'Hello World!'
    });
}