//code for pressing enter to make going through tour faster
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
}