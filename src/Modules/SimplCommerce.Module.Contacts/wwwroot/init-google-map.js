function initMap() {
    var uluru = { lat: 10.8019304, lng: 106.639198 };
    var map = new google.maps.Map(document.getElementById('googleMap'), {
        zoom: 14,
        center: uluru
    });
    var marker = new google.maps.Marker({
        position: uluru,
        map: map
    });
}
