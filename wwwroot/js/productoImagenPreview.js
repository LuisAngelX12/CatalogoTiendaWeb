function previewProductoImagen() {
    const fileInput = document.getElementById('ImagenFile');
    const imgPreview = document.getElementById('previewImage');

    if (!fileInput.files || !fileInput.files[0]) {
        imgPreview.style.display = 'none';
        return;
    }

    const reader = new FileReader();
    reader.onload = function (e) {
        imgPreview.src = e.target.result;
        imgPreview.style.display = 'block';
    };
    reader.readAsDataURL(fileInput.files[0]);
}