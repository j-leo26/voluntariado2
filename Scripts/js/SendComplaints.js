function sendEmail() {
    var nombre = document.getElementById("NombreQuejas").value;
    var correo = document.getElementById("Correo2").value;
    var tienecuenta = document.querySelector('Phone').value;
    var asunto = document.getElementById("Asunto").value;

    var link = "mailto:joselchavarro26@gmail.com"
        + "?subject=" + encodeURIComponent(asunto)
        + "&body=" + encodeURIComponent("Nombre: " + nombre + "\r\n"
       
            + "Correo: " + correo + "\r\n"
   
            + "Asunto: " + asunto);

    window.location.href = link;
}