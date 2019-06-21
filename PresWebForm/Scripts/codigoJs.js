
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
                alert(salida.d);
            }
        }
    });
};

function ingresarCliente() {
    //Agregar label al lado del boton de Ingresar para colocar el nombre del cliente
};