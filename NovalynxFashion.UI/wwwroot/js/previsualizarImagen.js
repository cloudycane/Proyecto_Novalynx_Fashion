/* Visualizar imagen */

$("#imagen").change(function () {

    let imagen = this.files[0];

    if (imagen["type"] != "image/jpeg" && imagen["type"] != "image/png") {

        $("#imagen").val("");
        $(".img-circle").attr("src", "data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==");
        alert("Debe subir una imagen en formato jpeg o png.");
    } else if (imagen["size"] > 200000) {
        $("#imagen").val("");
        $(".img.circle").attr("src", "data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==");
        alert("La imagen debe tener como máximo 2 MB.");
    } else {
        var datosImagen = new FileReader;
        datosImagen.readAsDataURL(imagen);

        $(datosImagen).on("load", function (event) {
            var rutaImagen = event.target.result;
            $(".img-circle").attr("src", rutaImagen);
        })
    }
})