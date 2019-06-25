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
                document.getElementById("MainContent_ClienteID").value = salida.d.substring(salida.d.indexOf(",")+1, salida.d.length);
                ingresarCliente(salida.d.substring(0, salida.d.indexOf(",")));
            }
        }
    });
};

function ingresarCliente(nombre) {
    document.getElementById("lblNombreCliente").innerText = "Bievenido " + nombre + "!";
    document.getElementById("btnIngresar").innerText = "Salir";
    var id = $("#MainContent_ClienteID").val();
    $("#ModalRegistro").modal('hide');

    var url = window.location.pathname;
    if (url.substring(0, 11) == "/misPedidos") {
        var tabla = "";
        $.ajax({
            type: "POST",
            url: "misPedidos.aspx/actualizarGrilla",
            data: JSON.stringify({ ID: id, Tabla: tabla }),
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (salida) {
                document.getElementById("sinCliente").innerHTML = "";
                document.getElementById("grilla").innerHTML = salida.d;
            }
        });
    }
    else {
        habilitarPedido();
    }

};

function registrarCliente() {
    nombre = document.getElementById("txtNombre").value;
    apellido = document.getElementById("txtApellido").value;
    dni = document.getElementById("txtDNI").value;
    usuario = document.getElementById("txtUsuarioR").value;
    contraseña = document.getElementById("txtContraseñaR").value;
    mail = document.getElementById("txtMail").value;
    telefono = document.getElementById("txtTelefono").value;
    fechaNacimiento = document.getElementById("dtpFechNac").value;

    $.ajax({
        type: "POST",
        url: "pedido.aspx/registrarCliente",
        data: JSON.stringify({ Nom: nombre, Ape: apellido, DNI: dni, Usuario: usuario, Pass: contraseña, Mail: mail, Tel: telefono, fechaNac: fechaNacimiento }),
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (salida) {
            ingresarCliente(salida.d);
        }
    });
};

function nombreCliente(id) {
    $.ajax({
        type: "POST",
        url: "pedido.aspx/nombreCliente",
        data: JSON.stringify({ ID: id }),
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (nombre) {
            ingresarCliente(nombre.d);
        }
    });
};


//=========== VALIDACIONES ========================

function habilitarPedido() {
    btnP = document.getElementById('MainContent_btnPedido');
    fecha = document.getElementById('MainContent_dtpFechaEntrega');
     boton = document.getElementById("btnIngresar");
    if (fecha.value == '' || boton.innerText == "Ingresar") {
        btnP.disabled = true;
    }
    else {
        btnP.disabled = false;
    }
}

function txtLlenos() {
    objeto = document.getElementById("tabR");
    if ($(objeto).hasClass("active")) {
        habilitarRegistro();
    }
    else {
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
};

function IngresarSalir() {
    var boton = document.getElementById("btnIngresar");
    if (boton.innerText == "Salir") {
        document.getElementById("ClienteID").value = "";
        document.getElementById("lblNombreCliente").innerText = "";
        document.getElementById("btnIngresar").innerText = "Ingresar";
        var url = window.location.pathname;
        if (url.substring(0, 11) == "/misPedidos") {
            document.getElementById("grilla").innerHTML = "";
            document.getElementById("sinCliente").innerHTML = "Ingrese o registrese para visualizar sus pedidos."
        }
        else {
            habilitarPedido();
        }
    }
    else {
        $("#ModalRegistro").modal('show');
    }
};

function validarEmail() {
    objeto = document.getElementById("txtMail");
    valueForm = objeto.value;
    var patron = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;
    if (valueForm.search(patron) == 0) {
        objeto.className = "form-control border border-success";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
    } else {
        objeto.className = "form-control border border-danger";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
    }
};

function sacarFoco(id) {
    objeto = document.getElementById(id);
    objeto.style.boxShadow = "0 0 0 0.2rem rgba(0,123,255,0)";
};

function enFoco(id) {
    objeto = document.getElementById(id);
    if (objeto.classList.contains("border-success")) {
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
    }
    else if (objeto.classList.contains("border-danger")) {
        objeto.className = "form-control border border-danger";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
    }
    else {
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(0,123,255,.25)";
    }
};

function validarVacio(id) {
    objeto = document.getElementById(id);
    valueForm = objeto.value;
    if (valueForm != "" && valueForm.length >= 2) {
        objeto.className = "form-control border border-success";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
    }
    else if (valueForm == "")
    {
        objeto.className = "form-control";
        objeto.style.border = "1px solid #ced4da";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(0,123,255,.25)";
    }
    else {
        objeto.className = "form-control border border-danger";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
    }

    if (objeto.id == "txtContraseñaR") {
        validarContraseña();
        sacarFoco("txtContraseñaRepetida");
    }
};

function habilitarRegistro() {
    var objeto = [document.getElementById("txtDNI"),
    document.getElementById("txtNombre"),
    document.getElementById("txtApellido"),
    document.getElementById("txtMail"),
    document.getElementById("txtUsuarioR"),
    document.getElementById("txtContraseñaR"),
    document.getElementById("txtContraseñaRepetida"),
    document.getElementById("txtTelefono"),
    document.getElementById("dtpFechNac")]
    success = true;
    for (var i = 0; i < 9; i++) {
        if (!objeto[i].classList.contains("border-success")) {
            success = false;
        }
    }
    if (success) {
        document.getElementById("btnRegistrarse").disabled = false;
    }
    else {
        document.getElementById("btnRegistrarse").disabled = true;
    }
};

function cambiarBtnIngresar(text) {
    if (text == "Registro") {
        document.getElementById("btnIngresarU").style.display = "none";
        document.getElementById("btnRegistrarse").removeAttribute("style");
    }
    else {
        document.getElementById("btnRegistrarse").style.display = "none";
        document.getElementById("btnIngresarU").removeAttribute("style");
    }
}

function validarDNI() {
    objeto = document.getElementById("txtDNI");
    valueForm = objeto.value;
    if (valueForm.length == 0) {
        objeto.className = "form-control";
        objeto.style.border = "1px solid #ced4da";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(0,123,255,.25)";
    }
    else if (valueForm.length < 7) {
        objeto.className = "form-control border border-danger";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
    }
    else {
        objeto.className = "form-control border border-success";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
    }
};

function maxNumeros() {
    objeto = document.getElementById("txtDNI");
    if (objeto.value.length > 8)
        objeto.value = objeto.value.slice(0, 8);
};

function validarContraseña() {
    pass = document.getElementById("txtContraseñaR");
    passR = document.getElementById("txtContraseñaRepetida");

    if (pass.value == passR.value) {
        passR.className = "form-control border border-success";
        passR.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
    }
    else if (passR.value == "") {
        passR.className = "form-control";
        passR.style.border = "1px solid #ced4da";
        passR.style.boxShadow = "0 0 0 0.2rem rgba(0,123,255,.25)";
    }
    else {
        passR.className = "form-control border border-danger";
        passR.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
    }
};

function validarNumero() {
    objeto = document.getElementById("txtTelefono");
    valueForm = objeto.value;
    if (valueForm.length == 0) {
        objeto.className = "form-control";
        objeto.style.border = "1px solid #ced4da";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(0,123,255,.25)";
    }
    else if (valueForm.length < 8) {
        objeto.className = "form-control border border-danger";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
    }
    else {
        objeto.className = "form-control border border-success";
        objeto.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
    }
};
