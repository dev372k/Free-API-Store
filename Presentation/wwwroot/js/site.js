// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    var bgImage = new Image();
    bgImage.loading = "lazy";
    bgImage.src = "../bg2.jpg";
    bgImage.onload = function () {
        document.body.style.backgroundImage = "url('../bg2.jpg')";
    };
});