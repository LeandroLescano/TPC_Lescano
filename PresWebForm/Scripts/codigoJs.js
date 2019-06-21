
function txtLlenos() {
    success = false;
    var txtUsuario = document.getElementById("txtUsuario");
    var txtPass = document.getElementById("txtContraseña");

    if (txtUsuario.value != "" && txtPass.value != "") {
        success = true;
    }
    if (success) {
        document.getElementById("btnIngresarU").disabled = false;

    }
    else {
        document.getElementById("btnIngresarU").disabled = true;
    }
}

function verificarUsuario() {
    var Usuario = document.getElementById("txtUsuario").value;
    var Password = document.getElementById("txtContraseña").value;
    $.ajax({
        type: "POST",
        url: "pedido.aspx/verificarUsuario",
        data: JSON.stringify({ UDNI: Usuario, Pass: Password }),
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (salida) {
            if (salida.d == "No existe") {
                alert("El usuario o contraseña ingresado no son válidos.");
            }
            else {
                ingresarCliente(salida.d);
            }
        }
    });
};

function ingresarCliente(nombre) {
    document.getElementById("lblNombreCliente").innerText = "Bievenido " + nombre + "!";
    document.getElementById("btnIngresar").innerText = "Salir";
    $("#ModalRegistro").modal('hide');
}

function IngresarSalir() {
    var boton = document.getElementById("btnIngresar");
    if (boton.innerText == "Salir") {
        document.getElementById("lblNombreCliente").innerText = "";
        document.getElementById("btnIngresar").innerText = "Ingresar";
    }
    else {
        $("#ModalRegistro").modal('show');
    }
}