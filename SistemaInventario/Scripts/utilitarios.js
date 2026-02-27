function F_Update_Division_HTML(str_nombre_div, str_valor_div) {

    $('#' + str_nombre_div).css('display', 'none');
    $('#' + str_nombre_div).html(str_valor_div);
    $('#' + str_nombre_div).css('display', 'block');

}

function F_General_Inicializar_UserControl_Paginacion(str_nombre_control_paginacion)
{

    $('#' + str_nombre_control_paginacion + '_hid_total_paginas').val(0);
    $('#' + str_nombre_control_paginacion + '_lbl_total_paginas').text(0);
    $('#' + str_nombre_control_paginacion + '_txt_pagina').val(0);

}

function F_General_Validar_UserControl_Paginacion(str_nombre_control_paginacion) {

    var str_pagina_actual;
    var str_pagina_total;

    str_pagina_actual = $('#' + str_nombre_control_paginacion + "_txt_pagina").val();
    str_pagina_total = $("#" + str_nombre_control_paginacion + "_hid_total_paginas").val();

    if (parseInt(str_pagina_actual) > (str_pagina_total)) {

        $('#' + str_nombre_control_paginacion + "_txt_pagina").val(str_pagina_total);

    }
    else {

        if (parseInt(str_pagina_actual) == 0) {

            $('#' + str_nombre_control_paginacion + "_txt_pagina").val("1");

        }
        else {

            $('#' + str_nombre_control_paginacion  + "_txt_pagina").val(str_pagina_actual);

        }

    }

}

function F_General_Validar_Resultado_Busqueda_UserControl_Paginacion(str_nombre_control_paginacion,str_tipo_busqueda,str_valor) {

    $('#' + str_nombre_control_paginacion + '_hid_total_paginas').val(str_valor);
    $('#' + str_nombre_control_paginacion + '_lbl_total_paginas').text(str_valor);

    if (str_tipo_busqueda == "0" & str_valor != "0") {

        //una nueva busqueda

        $('#' + str_nombre_control_paginacion + '_txt_pagina').val(1);

    }
    else {

        if (str_valor == "0") {

            $('#' + str_nombre_control_paginacion + '_txt_pagina').val(0);

        }

    }

}

function F_General_Limpiar_Control_Buscador_Instituto(str_contro_busqueda_instituto)
{

    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_codigo').val('');
    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_region').val('');
    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_descripcion').val('');
    $('#' + str_contro_busqueda_instituto + '_hid_bus_ins_id_instituto').val('');

}

function F_General_Limpiar_Control_Buscador_Docente(str_contro_busqueda_docente) {

    $('#' + str_contro_busqueda_docente + '_txt_bus_codigo').val('');
    $('#' + str_contro_busqueda_docente + '_txt_bus_docente').val('');
    $('#' + str_contro_busqueda_docente + '_hid_bus_id_docente').val('');

    F_General_Limpiar_Control_Buscador_Instituto(str_contro_busqueda_docente + "_" + "txt_bus_instituto");

    $('#' + str_contro_busqueda_docente + '_txt_busqueda').val('');
    
}

function F_General_Limpiar_Control_Buscador_Alumno(str_control_busqueda_alumno) {


    $('#' + str_control_busqueda_alumno + '_txt_bus_codigo').val('');
    $('#' + str_control_busqueda_alumno + '_txt_bus_alumno').val('');
    $('#' + str_control_busqueda_alumno + '_hid_bus_id_alumno').val('');

    F_General_Limpiar_Control_Buscador_Instituto(str_control_busqueda_alumno + "_" + "txt_bus_instituto");

    $('#' + str_control_busqueda_alumno + '_ddl_bus_especialidad').empty();

    $('#' + str_control_busqueda_alumno + '_txt_busqueda').val('');

}

function F_General_Limpiar_Control_Buscador_Curso(str_control_busqueda_curso) {

    $('#' + str_control_busqueda_curso + '_txt_bus_codigo').val('');
    $('#' + str_control_busqueda_curso + '_txt_bus_curso').val('');
    $('#' + str_control_busqueda_curso + '_hid_bus_id_curso').val('');

    $('#' + str_control_busqueda_curso + '_ddl_bus_especialidad').empty();
    $('#' + str_control_busqueda_curso + '_ddl_bus_curricula').empty();
    $('#' + str_control_busqueda_curso + '_txt_curso').val('');
    
}

function F_General_Limpiar_Control_Buscador_Unidad_Didactica(str_control_busqueda_curso) {

    $('#' + str_control_busqueda_curso + '_txt_bus_codigo').val('');
    $('#' + str_control_busqueda_curso + '_txt_bus_curso').val('');
    $('#' + str_control_busqueda_curso + '_hid_bus_id_curso').val('');

    $('#' + str_control_busqueda_curso + '_ddl_bus_especialidad').empty();
    $('#' + str_control_busqueda_curso + '_txt_curso').val('');

}

function F_General_Limpiar_Control_Buscador_Ubigeo(str_control_busqueda_ubigeo) {

    $('#' + str_control_busqueda_ubigeo + '_txt_bus_ubi_cod_ubigeo').val('');
    $('#' + str_control_busqueda_ubigeo + '_txt_bus_ubi_departamento').val('');
    $('#' + str_control_busqueda_ubigeo + '_txt_bus_ubi_provincia').val('');
    $('#' + str_control_busqueda_ubigeo + '_txt_bus_ubi_distrito').val('');
    $('#' + str_control_busqueda_ubigeo + '_hid_bus_id_distrito').val('');

}

function F_General_Asignar_Valores_Control_Buscador_Instituto(str_contro_busqueda_instituto,str_codigo,str_region,str_descripcion,str_id) 
{

    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_codigo').val(str_codigo);
    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_region').val(str_region);
    $('#' + str_contro_busqueda_instituto + '_txt_bus_ins_descripcion').val(str_descripcion);
    $('#' + str_contro_busqueda_instituto + '_hid_bus_ins_id_instituto').val(str_id);

}

function F_General_Asignar_Valores_Control_Buscador_Alumno(str_control_busqueda_alumno, str_codigo, str_alumno, str_id_alumno) {

    $('#' + str_control_busqueda_alumno + '_txt_bus_codigo').val(str_codigo);
    $('#' + str_control_busqueda_alumno + '_txt_bus_alumno').val(str_alumno);
    $('#' + str_control_busqueda_alumno + '_hid_bus_id_alumno').val(str_id_alumno);

}

function F_General_Asignar_Valores_Control_Buscador_Docente(str_contro_busqueda_docente, str_dni, str_docente, str_id_docente) {

    $('#' + str_contro_busqueda_docente + '_txt_bus_codigo').val(str_dni);
    $('#' + str_contro_busqueda_docente + '_txt_bus_docente').val(str_docente);
    $('#' + str_contro_busqueda_docente + '_hid_bus_id_docente').val(str_id_docente);
    
}

function F_General_Asignar_Valores_Control_Buscador_Unidad_Didactica(str_control_busqueda_ud, str_codigo, str_unidad_didactica, str_id_ud) {

    $('#' + str_control_busqueda_ud + '_txt_bus_codigo').val(str_codigo);
    $('#' + str_control_busqueda_ud + '_txt_bus_curso').val(str_unidad_didactica);
    $('#' + str_control_busqueda_ud + '_hid_bus_id_curso').val(str_id_ud);

}

function F_Habilitar_Menu_Modulo_Seguridad() {

    $('ul#menu_seguridad').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Configuracion_Basica() {

    $('ul#menu_configuracion_basica').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Admision_Mantenimiento() {

    $('ul#menu_admision').css('display', 'block');
    $('ul#menu_admision_mantenimiento').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Admision_Operaciones() {

    $('ul#menu_admision').css('display', 'block');
    $('ul#menu_admision_operaciones').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Admision_Operaciones_Exonerados() {

    $('ul#menu_admision').css('display', 'block');
    $('ul#menu_admision_operaciones').css('display', 'block');
    $('ul#menu_admision_exonerados').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Admision_Operaciones_Ordinarios() {

    $('ul#menu_admision').css('display', 'block');
    $('ul#menu_admision_operaciones').css('display', 'block');
    $('ul#menu_admision_ordinarios').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Academico_Mantenimiento() {

    $('ul#menu_academico').css('display', 'block');
    $('ul#menu_academico_mantenimiento').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Academico_Operaciones() {

    $('ul#menu_academico').css('display', 'block');
    $('ul#menu_academico_operaciones').css('display', 'block');

}

function F_Habilitar_Menu_Modulo_Academico_Reportes() {

    $('ul#menu_academico').css('display', 'block');
    $('ul#menu_academico_reportes').css('display', 'block');

}

function F_General_MostrarEspera(pboolMostrar) {
    if (pboolMostrar) {
        $('#dlgWait').dialog({
            autoOpen: false,
            modal: true,
            height: 'auto',
            resizable: false,
            dialogClass: 'alert'
        });

        $('.alert div.ui-dialog-titlebar').hide();
        $('.ui-button').remove();
        $('#dlgWait').dialog('open');
    }
    else {
        $('#dlgWait').dialog('close');
    }
}

function Date_AddDays(strFechaIni, intDias) {
    //  --> "intDias" + "strFechaIni" = "strFechaFin"
    var strFechaFin = '';

    milisegundos = parseInt(35 * 24 * 60 * 60 * 1000, 10);

    day = strFechaIni.split('/')[0];
    month = strFechaIni.split('/')[1];
    year = strFechaIni.split('/')[2];

    fecha = new Date(year, month - 1, day);

    //Obtenemos los milisegundos desde media noche del 1/1/1970
    tiempo = fecha.getTime();

    //Calculamos los milisegundos sobre la fecha que hay que sumar o restar...
    milisegundos = parseInt(intDias * 24 * 60 * 60 * 1000, 10);

    //Modificamos la fecha actual
    total = fecha.setTime(tiempo + milisegundos);

    day = fecha.getDate();
    month = fecha.getMonth() + 1;
    year = fecha.getFullYear();

    day = '0' + day;
    month = '0' + month;

    day = day.slice(-2);
    month = month.slice(-2);

    strFechaFin = day + '/' + month + '/' + year;

    return strFechaFin;
}

function forceNumber(element) {
    element
    .data("oldValue", '')
    .bind("paste", function (e) {
        var validNumber = /^[-]?\d+(\.\d{1,2})?$/;
        element.data('oldValue', element.val())
        setTimeout(function () {
            if (!validNumber.test(element.val()))
                element.val(element.data('oldValue'));
        }, 0);
    });
    element
    .keypress(function (event) {
        var text = $(this).val();
        if ((event.which != 46 || text.indexOf('.') != -1) && //if the keypress is not a . or there is already a decimal point
        ((event.which < 48 || event.which > 57) && //and you try to enter something that isn't a number
          (event.which != 45 || (element[0].selectionStart != 0 || text.indexOf('-') != -1)) && //and the keypress is not a -, or the cursor is not at the beginning, or there is already a -
          (event.which != 0 && event.which != 8))) { //and the keypress is not a backspace or arrow key (in FF)
            event.preventDefault(); //cancel the keypress
        }

        if ((text.indexOf('.') != -1) && (text.substring(text.indexOf('.')).length > 2) && //if there is a decimal point, and there are more than two digits after the decimal point
        ((element[0].selectionStart - element[0].selectionEnd) == 0) && //and no part of the input is selected
        (element[0].selectionStart >= element.val().length - 2) && //and the cursor is to the right of the decimal point
        (event.which != 45 || (element[0].selectionStart != 0 || text.indexOf('-') != -1)) && //and the keypress is not a -, or the cursor is not at the beginning, or there is already a -
        (event.which != 0 && event.which != 8)) { //and the keypress is not a backspace or arrow key (in FF)
            event.preventDefault(); //cancel the keypress
        }
    });
}

function F_Derecha() {
    $('.Derecha').css('text-align', 'right');
}


var VerificarSession = true;
$().ready(function () {
    //    $(document).everyTime(600000, function () {
    $(document).everyTime(10000, function () {
        if (!F_ValidaSesionActiva('', true)) return false;
    });
});

function F_SesionRedireccionar(directorio) {
    return F_ValidaSesionActiva(directorio, true);
}

var redireccionar = false;
function F_ValidaSesionActiva(directorio, Redir) {
    if (VerificarSession === false)
        return true;

    var Espera = false;
    var Resultado = false;
    redireccionar = Redir;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        url: '../Servicios/Servicios.asmx/KeepActiveSession?time=' + timex,
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {
            if (obj.d.SesionActiva === false) //cambiar a false
            {
                if (redireccionar == true) window.location.href = "../ErrorSession.aspx";
            }
            else {
                Resultado = true;

                var dt = new Date();
                var time = dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();

                var NombreUsuario = obj.d.Nombre; // +' ' + obj.d.Apellidos;
                if (NombreUsuario.trim() === '')
                    NombreUsuario = obj.d.NombreUsuario;

                if (NombreUsuario.trim() === '')
                    NombreUsuario = '';

                $('#lblAlmacen').text("sucursal : " + obj.d.Almacen);
                $('#imgUsuario').css('display', 'block');
                $('#imgUsuario').attr('src', '../Asset/images/mainuser.png');
                $('#lblNombreUsuario').text(NombreUsuario);
                $('#lblNombreEmpresa').text('sgae - ' + obj.d.Empresa);



                var rutaImg;
                rutaImg = "../files/temp/session/" + obj.d.ImagenNombre;
                var result = doesFileExist(rutaImg);
                if (result === false) {
                    rutaImg = "../../files/temp/session/" + obj.d.ImagenNombre;
                    result = doesFileExist(rutaImg);
                    if (result === false)
                        rutaImg = "../Asset/images/mainuser.png";
                    result = doesFileExist(rutaImg);
                    if (result === false)
                        rutaImg = "../Asset/images/mainuser.png";
                }
                //var img = new File([""], rutaImg);
                //                if (img.size === 0) {
                //rutaImg = "../files/temp/session/" + obj.d.ImagenNombre;
                //                    img = new File([""], rutaImg);
                //                    if (!img.isFile()) {
                //rutaImg = "../Asset/images/mainuser.png"
                //                    }

                var result = doesFileExist(rutaImg);

                $('#imgUsuario').attr('src', rutaImg);




            };
            redireccionar = false;
            Espera = true;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            alertify.log(textStatus + ": " + XMLHttpRequest.responseText);
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax
    return Resultado;
}


function F_ValidarCorreo(Correo) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test(Correo);
}

function F_ValidarFechaMayor(FechaInicial, FechaFinal) {
    ValorInicial = FechaInicial.split("/");
    ValorFinal = FechaFinal.split("/");

    // Verificamos que la fecha no sea posterior a la actual
    var Inicial = new Date(ValorInicial[2], (ValorInicial[1] - 1), ValorInicial[0]);
    var Final = new Date(ValorFinal[2], (ValorFinal[1] - 1), ValorFinal[0]);
    if (Inicial > Final)
        return true;
    else
        return false;
}


//Este fragmento de codigo a veces da errores, pero está bien que lo de
//es decir, son errores provocados, ya que valida la existencia de algunos 
//directorios para poder realizar diferentes acciones
function doesFileExist(urlToFile) {
    var xhr = new XMLHttpRequest();
    xhr.open('HEAD', urlToFile, false);
    xhr.send();

    if (xhr.status == "404") {
        return false;
    } else {
        return true;
    }
}





function F_PermisoOpcion(CodigoMenu, CodigoInterno, Opcion) {
    //Para mas facil compresion se utiliza los campos CodigoMenu y CodigoInterno
    //de las tablas Menu, MenuPaginas, y tambien MenuPaginasFunciones.... 
    //debes seguir las reglas de NORMALIZACION DE TABLAS para poder trabajar con ello
    //el parametro Opcion es (Opcional), se pasa en blanco '' cuando no es necesario
    //--
    //La funcion retorna 1/0 tipo texto, donde 1 es true o si tiene permiso.
    //--
    //PERMISOS DENTRO DE LA PAGINA: ------Administrador, Insertar, Consultar, Editar, Eliminar, Anular------
    //son los permisos especificos por cada pagina, se personalizan en la pagina Perfiles.
    //Quiero saber si el usuario logeado tiene permiso de Eliminar clientes..::
    //... se pasan las opciones: F_PermisoOpcion(1000, 1, 'Eliminar')
    //Donde 1000 es el menu de Maestros (Tabla Menu.CodigoMenu), 1 es la Pagina de Clientes (tabla MenuPaginas.CodigoInterno)...
    //--
    //FUNCIONES ESPECIALES DE PAGINA; Si quieres saber si tienes permiso a una funcion de pagina por ejemplo:
    //Permiso especial para aprobar pedidos "VENTAS >> NOTA DE PEDIDO >> APROBACION DE CREDITOS"
    //... se pasan las opciones: F_PermisoOpcion(3000, 777001, '')
    //donde 3000 es el menu de Ventas (Tabla Menu.CodigoMenu), y 777001 Funcion (tabla MenuPaginasFunciones.CodigoInterno)



    var Espera = false; var Resultado = "0";
    var dtx = new Date(); var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Seguridad.asmx/F_PermisoOpcion',
        data: "{'CodigoMenu':'" + CodigoMenu + "','CodigoInterno':'" + CodigoInterno + "','Opcion':'" + Opcion + "'}",
        dataType: "json",
        async: false,
        success: function (obj, status) {
            Resultado = obj.d;
            Espera = true;

            if (Resultado === "0") {

                var textoMensaje = "";
                switch (Opcion) {
                    case "Administrador": textoMensaje = "NO TIENE PERMISO DE ADMINISTRADOR DE PAGINA"; break;
                    case "Insertar": textoMensaje = "NO TIENE PERMISO DE GRABAR NUEVOS DATOS EN ESTA PAGINA"; break;
                    case "Consultar": textoMensaje = "NO TIENE PERMISO DE CONSULTAR EN ESTA PAGINA"; break;
                    case "Editar": textoMensaje = "NO TIENE PERMISO DE MODIFICAR INFORMACION EN ESTA PAGINA"; break;
                    case "Eliminar": textoMensaje = "NO TIENE PERMISO DE ELIMINAR DATOS EN ESTA PAGINA"; break;
                    case "Anular": textoMensaje = "NO TIENE PERMISO DE ANULAR REGISTROS EN ESTA PAGINA"; break;
                    default: textoMensaje = "NO TIENE PERMISO A EJECUTAR ESTA OPCION"; break;
                }
                alertify.error(textoMensaje);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            alertify.log(textStatus + ": " + XMLHttpRequest.responseText);
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax
    return Resultado;
}

function F_PermisoOpcion_SinAviso(CodigoMenu, CodigoInterno, Opcion) {
    //Para mas facil compresion se utiliza los campos CodigoMenu y CodigoInterno
    //de las tablas Menu, MenuPaginas, y tambien MenuPaginasFunciones.... 
    //debes seguir las reglas de NORMALIZACION DE TABLAS para poder trabajar con ello
    //el parametro Opcion es (Opcional), se pasa en blanco '' cuando no es necesario
    //--
    //La funcion retorna 1/0 tipo texto, donde 1 es true o si tiene permiso.
    //--
    //PERMISOS DENTRO DE LA PAGINA: ------Administrador, Insertar, Consultar, Editar, Eliminar, Anular------
    //son los permisos especificos por cada pagina, se personalizan en la pagina Perfiles.
    //Quiero saber si el usuario logeado tiene permiso de Eliminar clientes..::
    //... se pasan las opciones: F_PermisoOpcion(1000, 1, 'Eliminar')
    //Donde 1000 es el menu de Maestros (Tabla Menu.CodigoMenu), 1 es la Pagina de Clientes (tabla MenuPaginas.CodigoInterno)...
    //--
    //FUNCIONES ESPECIALES DE PAGINA; Si quieres saber si tienes permiso a una funcion de pagina por ejemplo:
    //Permiso especial para aprobar pedidos "VENTAS >> NOTA DE PEDIDO >> APROBACION DE CREDITOS"
    //... se pasan las opciones: F_PermisoOpcion(3000, 777001, '')
    //donde 3000 es el menu de Ventas (Tabla Menu.CodigoMenu), y 777001 Funcion (tabla MenuPaginasFunciones.CodigoInterno)



    var Espera = false; var Resultado = "0";
    var dtx = new Date(); var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Seguridad.asmx/F_PermisoOpcion',
        data: "{'CodigoMenu':'" + CodigoMenu + "','CodigoInterno':'" + CodigoInterno + "','Opcion':'" + Opcion + "'}",
        dataType: "json",
        async: false,
        success: function (obj, status) {
            Resultado = obj.d;
            Espera = true;

            if (Resultado === "0") {

                var textoMensaje = "";
                switch (Opcion) {
                    case "Administrador": textoMensaje = "NO TIENE PERMISO DE ADMINISTRADOR DE PAGINA"; break;
                    case "Insertar": textoMensaje = "NO TIENE PERMISO DE GRABAR NUEVOS DATOS EN ESTA PAGINA"; break;
                    case "Consultar": textoMensaje = "NO TIENE PERMISO DE CONSULTAR EN ESTA PAGINA"; break;
                    case "Editar": textoMensaje = "NO TIENE PERMISO DE MODIFICAR INFORMACION EN ESTA PAGINA"; break;
                    case "Eliminar": textoMensaje = "NO TIENE PERMISO DE ELIMINAR DATOS EN ESTA PAGINA"; break;
                    case "Anular": textoMensaje = "NO TIENE PERMISO DE ANULAR REGISTROS EN ESTA PAGINA"; break;
                    default: textoMensaje = "NO TIENE PERMISO A EJECUTAR ESTA OPCION"; break;
                }
                //alertify.error(textoMensaje);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            alertify.log(textStatus + ": " + XMLHttpRequest.responseText);
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax
    return Resultado;
}


function F_ParametrosPagina(Parametro, CodigoMenu, CodigoInterno) {

    var Espera = false; var Resultado = "0";
    var dtx = new Date(); var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_ParametrosListar',
        data: "{'Parametro':'" + Parametro + "','CodigoMenu':'" + CodigoMenu + "','CodigoInterno':'" + CodigoInterno + "'}",
        dataType: "json",
        async: false,
        success: function (obj, status) {
            if (Parametro === '')
                Resultado = obj.d; //si no se le pasa parametro solo pregunta por el listado
            else
                Resultado = obj.d[0].Valor; //si pasa un parametro pregunta por un valor en especifico

            Espera = true;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

            alertify.log(textStatus + ": " + XMLHttpRequest.responseText);
            Espera = true;
            Resultado = "0";
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax
    return Resultado;
}


function F_ContarRowsGrilla(nombreGrilla, nombreCheck, nombreColumna) {
    var chkSi = ''; var colVal = '';
    var cc = 0;

    $('#MainContent_' + nombreGrilla + ' :checkbox').each(function () {
        chkSi = '#' + this.id;
        colVal = chkSi.replace(nombreCheck, nombreColumna);
        if ($(colVal).val() === "" & $(colVal).text() === "") {} else 
        {
        cc++;
        }
    });

    return cc;
}

function F_Numerar_Grilla(NombreGrilla, NombreLabel) {
    var Control = $('#MainContent_' + NombreGrilla + '_' + NombreLabel + '_0').text();
    var C = 0;
    $('#MainContent_' + NombreGrilla + ' .detallesart').each(function () {
        C++;
    });
    if (C == 1 & Control == '')
        C = 0;
    return C;
}

function Validacionguia(SerieGuia, NumeroGuia, FechaTraslado, Destino, Transportista, RUCTransportista, placa, Licencia, NuBultos, Peso, Conductor, DniConductor
, CodtipoTransportista, Direccion, CodConductor) {
    var cadenavalidacionguia = 'Ingresar los sgtes. Datos DE LA GUIA:';

    if (RUCTransportista == '11111111' | RUCTransportista == '55555555555')
        cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Cuando Aplica una Guia, no puede ser cliente varios';

    if (NumeroGuia == '')
        cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Numero de Guia';

    if (FechaTraslado == '')
        cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Fecha de Traslado';

    if (Destino == null)
        cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Llegada';
    if ((SerieGuia).substr(0, 1) == 'T') {
        if (CodtipoTransportista == 2) {
            if (placa == '') {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Placa'
            }
            if (Licencia == '') {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Licencia'
            }
            if (Peso == '' || Peso == 0) {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Peso'
            }
            if (NuBultos == '' || NuBultos == 0) {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'NuM Bultos'
            }
            if (Conductor == '') {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Conductor'
            }
            if (DniConductor == '') {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Dni Conductor'
            }
            if (CodConductor == 0) {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Conductor'
            }
        }
        else if (CodtipoTransportista == 1) {

            if (RUCTransportista == '') {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'RUC Transportista'
            }
            if (Transportista == '') {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Razon social Transportista'
            }
            if (Direccion == null) {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Direccion Transportista'
            }
            if (Peso == '' || Peso == 0) {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Peso'
            }
            if (NuBultos == '' || NuBultos == 0) {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'NuM Bultos'
            }

        }
        else {
            if (placa == '') {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Placa'
            }
            if (Peso == '' || Peso == 0) {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'Peso'
            }
            if (NuBultos == '' || NuBultos == 0) {
                cadenavalidacionguia = cadenavalidacionguia + '<p></p>' + 'NuM Bultos'
            }
        }
    }
    if (cadenavalidacionguia != 'Ingresar los sgtes. Datos DE LA GUIA:') {
        return '<p></p>' + cadenavalidacionguia;
    } else {
        cadenavalidacionguia = ''
    }
    return cadenavalidacionguia;
}

function BloqueoTipoTransportista(SerieGuia, NumeroGuia, FechaTraslado, Destino, Transportista, RUCTransportista, placa, Licencia, NuBultos, Peso, Conductor, DniConductor
, CodtipoTransportista, Direccion, CodConductor, Marca, botondestino, botontransportista, chkguia, CodTransportista) {

    if ((SerieGuia).substr(0, 1) == 'T') {
        if (CodtipoTransportista == 2 && $(chkguia).is(':checked')) {
            $(RUCTransportista).prop("disabled", true);
            $(Transportista).prop("disabled", true);
            $(Direccion).prop("disabled", true);
            $(placa).prop("disabled", false);
            $(Licencia).prop("disabled", false);
            $(Conductor).prop("disabled", false);
            $(DniConductor).prop("disabled", false);
            $(Marca).prop("disabled", false);
            $(botondestino).prop("disabled", false);
            $(botontransportista).prop("disabled", false);
            //
            $(RUCTransportista).val('');
            $(Transportista).val('');
            $(placa).val('');
            $(Licencia).val('');
            $(Conductor).val('');
            $(Marca).val('');
            $(DniConductor).val('');
            $(Direccion).empty();
            $(CodConductor).val(0);
            $(CodTransportista).val(0);
        }
        else if (CodtipoTransportista == 1 && $(chkguia).is(':checked')) {
            $(RUCTransportista).prop("disabled", false);
            $(Transportista).prop("disabled", false);
            $(Direccion).prop("disabled", false);
            $(placa).prop("disabled", false);
            $(Licencia).prop("disabled", false);
            $(Conductor).prop("disabled", true);
            $(DniConductor).prop("disabled", true);
            $(Marca).prop("disabled", false);
            $(botondestino).prop("disabled", false);
            $(botontransportista).prop("disabled", false);
            //
            $(RUCTransportista).val('');
            $(Transportista).val('');
            $(placa).val('');
            $(Marca).val('');
            $(Licencia).val('');
            $(Conductor).val('');
            $(Direccion).empty();
            $(DniConductor).val('');
            $(CodConductor).val(0);
        }
        else {
            $(RUCTransportista).prop("disabled", true);
            $(Transportista).prop("disabled", true);
            $(Direccion).prop("disabled", true);
            $(placa).prop("disabled", false);
            $(Licencia).prop("disabled", true);
            $(Conductor).prop("disabled", true);
            $(DniConductor).prop("disabled", true);
            $(Marca).prop("disabled", true);
            $(botondestino).prop("disabled", true);
            $(botontransportista).prop("disabled", true);
            //
            $(RUCTransportista).val('');
            $(Transportista).val('');
            $(Marca).val('');
            $(placa).val('');
            $(Licencia).val('');
            $(Conductor).val('');
            $(Direccion).empty();
            $(DniConductor).val('');
            $(CodConductor).val(0);
        }
    } else {
        $(RUCTransportista).prop("disabled", true);
        $(Transportista).prop("disabled", true);
        $(Direccion).prop("disabled", true);
        $(placa).prop("disabled", false);
        $(Licencia).prop("disabled", true);
        $(Conductor).prop("disabled", true);
        $(DniConductor).prop("disabled", true);
        $(Marca).prop("disabled", true);
        $(botondestino).prop("disabled", true);
        $(botontransportista).prop("disabled", true);
        //
        $(RUCTransportista).val('');
        $(Transportista).val('');
        $(Marca).val('');
        $(placa).val('');
        $(Licencia).val('');
        $(Conductor).val('');
        $(Direccion).empty();
        $(DniConductor).val('');
        $(CodConductor).val(0);
    }
    return false;
}



function F_GuardarDireccion(Ruc, CodDocumentoVenta, CodCtacte, Razonsocial, FlagTraslado, Ubigeo, Direccion, ddldireccion, ddldireccionDestino, Codtipodoc) {
    if ($(Razonsocial).val() == '') {
        $(ddldireccion).empty();
        $(ddldireccionDestino).empty();
        return false
    }

    if (FlagTraslado != 1)
        FlagTraslado = 0

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarTemporal',
        data: "{'NroRuc':'" + Ruc + "','CodDocumentoVenta':'" + $(CodDocumentoVenta).val() + "','CodCtacte':'" + CodCtacte
        + "','Razonsocial':'" + $(Razonsocial).val().replace("'", '').replace("-", '')
        + "','FlagTraslado':'" + FlagTraslado + "','Ubigeo':'" + Ubigeo + "','Direccion':'" + Direccion + "','Codtipodoc':'" + Codtipodoc + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $(ddldireccion).empty();
                $(ddldireccionDestino).empty();
                $.each(data.rows, function (index, item) {
                    $(ddldireccion).append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                    $(ddldireccionDestino).append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                });

                $(CodDocumentoVenta).val(data.rows[0].Temporal);

            }

            catch (x) { }
            MostrarEspera(false);
        },
        complete: function () {


        },
        error: function (response) {
            //   alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

function F_ListaDireccionTemporal(CodDocumentoVenta, ddldireccion, ddldireccionDestino, FlagTraslado) {


    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccionTemporal_Listar',
        data: "{'CodDocumentoVenta':'" + $(CodDocumentoVenta).val() + "','FlagTraslado':'" + FlagTraslado + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $(ddldireccion).empty();
                $(ddldireccionDestino).empty();
                $.each(data.rows, function (index, item) {
                    $(ddldireccion).append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                    $(ddldireccionDestino).append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                });


                $(CodDocumentoVenta).val(data.rows[0].Temporal);

            }

            catch (x) { alertify.log('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        complete: function () {


        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });

    return false;
}

function F_GrabarDireccion(CodDocumentoVenta, coddepartamento, codprovincia, coddistrito, direccion, correo1, correo2, codcliente, ddldireccion, hfCodDireccionTemporal, txtDistrito,
ddldireccionDestino, FlagTraslado, NroRuc, RazonSocial) {

    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodTemporal: $(CodDocumentoVenta).val(),
            Filtro_CodDepartamento: $(coddepartamento).val(),
            Filtro_CodProvincia: $(codprovincia).val(),
            Filtro_CodDistrito: $(coddistrito).val(),
            Filtro_Direccion: $(direccion).val(),
            Filtro_correo1: $(correo1).val(),
            Filtro_correo2: $(correo2).val(),
            Filtro_codCliente: $(codcliente).val(),
            Filtro_CodDireccionTemporal: $(hfCodDireccionTemporal).val(),
            Filtro_RazonSocial: $(RazonSocial).val(),
            Filtro_NroRuc: $(NroRuc).val(),
            Filtro_FlagTraslado: FlagTraslado
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDireccionTemporal_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Grabo Correctamente') {
                    F_Update_Division_HTML('div_DireccionTemporal', result.split('~')[2]);

                    $(coddepartamento).val('0');
                    $(hfCodDireccionTemporal).val('0');
                    $(codprovincia).val('0');
                    $(coddistrito).val('0');
                    $(direccion).val('');
                    $(correo1).val('');
                    $(correo2).val('');
                    $(txtDistrito).val('');
                    $(CodDocumentoVenta).val(result.split('~')[5])
                    $('#div_DireccionMultiple').dialog('close');
                    F_ListaDireccionTemporal(CodDocumentoVenta, ddldireccion, ddldireccionDestino, result.split('~')[4]);
                    $(ddldireccion).val(result.split('~')[3]);
                    alertify.log('Se Grabo Correctamente.');
                }
                else
                    alertify.log(result.split('~')[1]);

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_EliminarDireccion(CodDocumentoVenta, CodDocumentoVentaDireccion, ddldireccion, txtDistrito) {

    try {

        var objParams = {
            Filtro_CodTemporal: $(CodDocumentoVenta).val(),
            Filtro_CodDireccionTemporal: $(CodDocumentoVentaDireccion).val()
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarDireccionTemporal_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Elimino Correctamente') {
                    F_Update_Division_HTML('div_DireccionTemporal', result.split('~')[2]);
                    alertify.log('Se Elimino Correctamente.');
                    $(coddepartamento).val('0');
                    $(CodDocumentoVentaDireccion).val('0');
                    $(codprovincia).val('0');
                    $(coddistrito).val('0');
                    $(direccion).val('');
                    $(correo1).val('');
                    $(correo2).val('');
                    $(txtDistrito).val('');

                    F_ListaDireccionTemporal(CodDocumentoVenta, ddldireccion);

                }
                else
                    alertify.log(result.split('~')[1]);

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function BuscarDireccionCotizacion(CodDocumentoVenta, CodDireccion, ddldireccion, ddldireccionDestino, Codtipodoc) {

    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodTemporal: $(CodDocumentoVenta).val(),
            Filtro_CodDireccion: CodDireccion,
            Filtro_Codtipodoc: Codtipodoc
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_BuscarDireccionCotizacion_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Grabo Correctamente') {

                    $(ddldireccion).val(result.split('~')[3]);
                    $(ddldireccionDestino).val(result.split('~')[3]);

                }
                else
                    alertify.log(result.split('~')[1]);

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function BloqueoGuiaInterna(TipoDocumento, TipoTransportista, Proveedor, MotivoTrabajo, botondestino, NroRucTransportista
, Tranpostista, direccionTransportista, botontransportista, nrobulto, peso, dniconducto, conductor, placa, licencia) {

    if ((TipoDocumento) == 4) {

        $(TipoTransportista).prop("disabled", true);
        $(Proveedor).prop("disabled", true);
        $(MotivoTrabajo).prop("disabled", true);
        $(botondestino).prop("disabled", true);
        $(NroRucTransportista).prop("disabled", true);
        $(Tranpostista).prop("disabled", true);
        $(direccionTransportista).prop("disabled", true);
        $(botontransportista).prop("disabled", true);
        $(nrobulto).prop("disabled", true);
        $(peso).prop("disabled", true);
        $(dniconducto).prop("disabled", true);
        $(conductor).prop("disabled", true);
        $(placa).prop("disabled", true);
        $(licencia).prop("disabled", true);
        //

        $(MotivoTrabajo).val('7');
        $(Tranpostista).val('');
        $(direccionTransportista).empty();
        $(nrobulto).val('');
        $(peso).val('');
        $(dniconducto).val('');
        $(conductor).val('');
        $(placa).val('');
        $(licencia).val('');


    }
    else {
        $(TipoTransportista).prop("disabled", false);
        $(Proveedor).prop("disabled", false);
        $(MotivoTrabajo).prop("disabled", false);
        $(botondestino).prop("disabled", false);
        $(NroRucTransportista).prop("disabled", false);
        $(Tranpostista).prop("disabled", false);
        $(direccionTransportista).prop("disabled", false);
        $(botontransportista).prop("disabled", false);
        $(nrobulto).prop("disabled", false);
        $(peso).prop("disabled", false);
        $(dniconducto).prop("disabled", false);
        $(conductor).prop("disabled", false);
        $(placa).prop("disabled", false);
        $(licencia).prop("disabled", false);
        //


    }

    return false;
}

function F_BuscarDatosPorRucDniENTERONBLUR(RucDni, CodTipoCtaCte) {
    var data;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCCUENTACORRIENTE_ENTER_ONBLUR',
        data: "{'NroRuc':'" + RucDni + "','CodTipoCtaCte':'" + CodTipoCtaCte + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            data = dbObject.d;
            if (data.length > 0) {
                try {
                    return data;
                }
                catch (x) { alertify.log(x); }
            }
        },
        error: function (response) {
            alertify.log(response.responseText);
        },
        failure: function (response) {
            alertify.log(response.responseText);
        }
    });
    return data;
}

function F_APISUNAT(urlapisunat, NroRuc, tokenapisunat) {
    var data;

    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: urlapisunat + NroRuc + tokenapisunat,
        dataType: "json",
        async: true,
        success: function (dbObject) {
            MostrarEspera(true);
            data = dbObject.d;
            return data;
        },
        error: function (response) {
            toastr.warning(response.responseText);
        },
        failure: function (response) {
            toastr.warning(response.responseText);
        }
    });

    return data;
}

// esta funcion se encarga de busca la url y el token del api para la busque en la parte de padronsunat
function F_API_RUC_Buscar_Global() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_API_RUC_Buscar',
        data: "{}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $('#hfurlapisunat').val(data[0].split(',')[0]);
            $('#hftokenapisunat').val(data[0].split(',')[1]);
            return true;
        },
        complete: function () {
        },
        error: function (response) {
            toastr.warning(response.responseText);
        },
        failure: function (response) {
            toastr.warning(response.responseText);
        }
    });
    return false;
}
