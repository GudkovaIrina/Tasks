var image = document.querySelector("#image");
image.addEventListener("change", function () {
    var files = this.files;
    var showImage = document.querySelector("#show-image");
    showImage.src = window.URL.createObjectURL(files[0]);
}, true);