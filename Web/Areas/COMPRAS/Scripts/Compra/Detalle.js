var Detalle = function () {
    "use strict"
    return {
        // ---------------------------------
        //           Propiedades 
        // ---------------------------------
        //..

        // ---------------------------------
        //           Metodos 
        // ---------------------------------
        init: function () {
            console.log("((init))");
            this.handleValidator();
        },

        handleValidator: function () {
            $.validator.unobtrusive.parse($("#Registrar form"));
        },

        onSuccess: function (result) {
            if (result.Success) {
                swal({
                    title: "Correcto",
                    text: result.Message,
                    type: "success"
                }, function () {
                    // recarga grilla y se mueve a la pagina 1                    
                    $("#Index").find("#grid").data("kendoGrid").dataSource.read();
                    // oculta modal
                    modal.modal('hide');
                });

            } else {
                swal({
                    title: "Error",
                    text: result.Message,
                    type: "error"
                });
            }
        },

        onAgregarProducto: function () {           
            // Obtiene los valores de los controles
            var productoId = $("#Registrar").find("#ProductoId").data("kendoDropDownList");
            var cantidadProducto = productoId.dataItem().Cantidad;

            var cantidad = $("#Registrar").find("#Cantidad").data("kendoNumericTextBox");
            var cantidadIngresada = cantidad.value();

            if (typeof cantidadProducto == 'undefined' || cantidadIngresada == null) {
                swal({
                    title: "Error",
                    text: "Debe especificar una producto y cantidad previamente.",
                    type: "error"
                });
                return;
            }
            
            // Evalua las cantidades especificadas
            if (cantidadIngresada > cantidadProducto) {
                swal({
                    title: "Error",
                    text: "No es posible adquirir la cantidad de productos especificados ya que supera los disponibles.",
                    type: "error"
                });

                return;
            }
            
            // Valida la existencia del producto de ser asi, modifica sus cantidades y valores
            var item;
            var elProductoExiste = false; 
            var grid = $("#Registrar #productosCompraGrid").data("kendoGrid");
            var ds = grid.dataSource.data();

            for (var i = 0; i < ds.length; i++) {
                item = ds[i];
                if (item.Id == productoId.dataItem().Id) {
                    item.Cantidad += cantidadIngresada;
                    item.ValorTotal += item.ValorUnitario * cantidadIngresada;

                    elProductoExiste = true;
                    grid.refresh();
                    break;
                }
            }            

            // Adiciona el producto a la lista
            if (!elProductoExiste) {
                var dataItem = {
                    Id: productoId.dataItem().Id,
                    Nombre: productoId.dataItem().Nombre,
                    Cantidad: cantidadIngresada,
                    ValorUnitario: productoId.dataItem().Valor,
                    ValorTotal: productoId.dataItem().Valor * cantidadIngresada
                };
                Utils.addGridDataItem("#Registrar #productosCompraGrid", dataItem);
            }

            // Se calcula el total
            var calculoTotal = 0;
            for (var i = 0; i < ds.length; i++) {
                calculoTotal += ds[i].ValorTotal;
            } 
            var total = $("#Registrar #Total").data("kendoNumericTextBox");
            total.value(calculoTotal);
        },

        removeGridRow: function (e) {
            Utils.removeGridDataItem(e, "#Registrar #productosCompraGrid");
        },

        onBegin: function onBegin(jqXHR, settings) {
            var data = $(this).serializeObject();
            data["ProductosCompra"] = Utils.getGridDataSource("#Registrar #productosCompraGrid");
            settings.data = jQuery.param(data);
        }








    };
}();



