document.addEventListener("DOMContentLoaded", function () {
    const fileInput = document.getElementById("ImagenFile");
    const preview = document.getElementById("preview");
    const imagenUrlInput = document.getElementById("ImagenUrl");

    fileInput.addEventListener("change", function () {
        const file = this.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                preview.src = e.target.result;
                preview.classList.remove("d-none");
                imagenUrlInput.value = e.target.result; // se guarda como base64 temporal
            };
            reader.readAsDataURL(file);
        }
    });
});
