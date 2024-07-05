$(function () {

    fn_ListarProductos();

    $('#btnAgregar').on('click', function (evt) {
        evt.preventDefault();

       // dtCheckListTiendas.ajax.reload(null, false);
        // fn_ListarProductos1();
        console.log("Clic a agregar");
        //Llamar al modal
        $('#modalAgregarProducto').modal({ backdrop: "static", show: true });
    })


    //$(document).on('click', '.btn-agregar', function (evt) {
    //    evt.preventDefault();
    //    let ptoVenta = $(this).data('id');

    //    // Obtener la fila actual
    //    let fila = $(this).closest('tr');

    //    // Obtener el texto de la columna 2 (índice 1)
    //    let nombrePuntoVenta = fila.find('td:eq(1)').text();

    //    // console.log(ptoVenta);
    //    fn_ObtenerCalificacionCabecera(ptoVenta);

    //    // Actualizar el título del modal
    //    $('#tituloModalActPri').text(nombrePuntoVenta);
    //    //Llamar al modal
    //    $('#modalActividadesPrin').modal({ backdrop: "static", show: true });
    //})




})



var fn_ListarProductos = function (evt) {
    dtCheckListTiendas = $('#DM_ListProductos').DataTable({
        processing: true,
        //serverSide: true,
        order: [[1, 'desc']],
        /*language: language_spanish,*/
        ajax: {
            url: '/Productos/listarProductos',
            type: 'GET',
            //data: function (d) {
            //    d.stEstado = $('#Estado').val()
            //},
            statusCode: {
                401: function () {
                    //fn_SessionExpirada()
                }
            },
        },
        columns: [
            {
                data: "id", render: function (data, type, row) {
                    var el = '<div>';
                  /*  el += "<div><a href='#' class='btn btn-dark-grey tooltips btn-show-editProduct' data-placement='top' data-original-title='show'><i class='fa fa-search' title='Editar Producto'></i></a> ";*/

                    el += "<a href='#' class='btn btn-primary tooltips btn-editar' data-placement='top' data-idProducto='"+data+"' data-original-title='show'>Editar</a> ";
                    el += "<a href='#' class='btn btn-danger tooltips btn-eliminar' data-placement='top'  data-idProducto='"+data+"' data-original-title='show'>Eliminar</a> ";

                    //if (row.stEstadoCabeceraCodigo === "2") {
                    //    el += "<a href='#' class='btn btn-primary tooltips btn-iniciar' data-placement='top' data-original-title='show' data-ptoVenta='" + data + "' title='Iniciar' >Iniciar</a>";
                    //}
                    //else
                    //{
                    //    el += "<a href='#' class='btn btn-default tooltips btn-continuar' data-placement='top' data-original-title='show' data-ptoVenta='" + data + "' title='Continuar Proceso'>Continuar</a> ";
                    //    el += "<a href='#' class='btn btn-success tooltips btn-terminar' data-placement='top' data-original-title='show' data-ptoVenta='" + data + "' title='Terminar Proceso'>Terminar</a> ";

                    //}
                    el += "</div>";
                    return el;
                }
            },

            //{
            //    //, width: '150px'
            //    data: "id", render: function (data, type, row) {
            //        if (data != '') {
            //            return data + '-' + row.stPvtNombre;
            //        }
            //        else {
            //            // Si serieGuia_Asociada  está vacío, retornar vacio 
            //            return '';
            //        }
            //    }
            //},
            { data: "id" },
            { data: "nombre" },
            { data: "precio" }

        ],
        //footerCallback: function (row, data, start, end, display) {
        //    var api = this.api(), data;

        //    var types = api.columns(1).data();
        //    // Total over all pages
        //    total = api.column(1).data().reduce(function (a, b, i) {
        //        return i + 1;
        //    }, 0);

        //    // Update footer
        //    $(api.column(3).footer()).html("<span style='font-size: 1.8rem; font-weight: bold' id='TotalPtoVenta'>" +
        //        Number(total) + "</span>");
        //},
        createdRow: function (row, data, dataIndex) {
            var menuDisabled = [];
            //$(row).attr('tabindex', 0);
            $(row).find('td').eq(0).addClass('center');
            //$(row).find('td:eq(1)').attr('data-idTipoTransaccion', data.referenciatransacciontipo).attr('data-idNumeroTransaccion', data.referenciatransaccionnumero);
          /*  $(row).find('td:eq(2)').attr('data-idEstado', data.stEstadoCabeceraCodigo);*/
        },
        //dom: "lBfrtip",
        //buttons: [
        //    { extend: "pdf", title: "export-table-pdf" },
        //    { extend: "excel", title: "export-table-excel" },
        //    { extend: "csv", title: "export-table-csv" },
        //    { extend: "copy" },
        //    { extend: "print" }
        //],
    });
}


var fn_ListarProductos1 = function (evt) {

    // Realizar la llamada AJAX
    $.ajax({
        url: '/Productos/listarProductos',
        type: 'GET', // o 'GET' según la configuración de tu controlador
        //data: {
        //    stEstado: $('#Estado').val(),

        //},
        success: function (response) {
            // Manejar la respuesta del servidor (response)
            console.log(response);
        },
        error: function (error) {
            // Manejar errores
            console.log(error);
        }
    });


}