
var Registrar = function () {
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

        seleccionarCliente: function (event) {
            if (event.sender.value() != "") {
                var data = event.sender.dataItem();
                var grid = $("#gridOrden").data("kendoGrid");
                var total = 0;
                $("#Nombre").val(data.Nombre);
                $("#Cabina").val(data.Cabina);
                $("#FechaEmbarque").data("kendoDatePicker").value(data.FechaEmbarque);
                $("#FechaDesembarque").data("kendoDatePicker").value(data.FechaDesembarque);
                grid.dataSource.read();
            }
        },

        calcularTotal: function (event) {
            var total = 0;
            $.each(event.sender.dataSource.data(), function (index, element) {
                total += element.Total;
            });
            $("#Total").data("kendoNumericTextBox").value(total);
        },

        getClientId: function (){
            return {
                id : $("#ClienteId").data("kendoDropDownList").value()
            }
        },



        handleValidator: function(){
            $.validator.unobtrusive.parse($("#Registrar form"));
        },

        onBegin: function (jqXHR, settings) {
            var data = $(this).serializeObject();
            data["Ordenes"] = Utils.getGridDataSource("#gridOrden");
            settings.data = $.param(data);
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
        }
        
    }
}();



