var Index = function () {
    "use strict";
    return {
        // ---------------------------------
        //           Propiedades 
        // ---------------------------------
        actionTemplate: null,

        // ---------------------------------
        //           Metodos 
        // ---------------------------------

        init: function () {
            console.log("((init))");
            this.handleTemplates();
        },

        handleTemplates: function () {
            this.actionTemplate = kendo.template($('#Index #actionTemplate').html());
        },

        eliminarProducto: function (e) {
            e.preventDefault();
            var grid = $("#Index").find("#grid").data("kendoGrid");
            var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
            var id = dataItem.Id;

            swal({
                title: "Eliminación",
                text: "¿Esta seguro de eliminar el registro seleccionado?",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Si, estoy seguro"
            }, function () {
                $.ajax({
                    method: "POST",
                    url: "/INVENTARIOS/Producto/Eliminar/" + id
                })
                .done(function (result) {
                    if (result.Success) {
                        swal("Correcto", result.Message, "success");
                        grid.dataSource.read();
                    } else {
                        swal({title: "Error", text: result.Message, type: "error"});
                    }
                    
                });
                
            });
        }

        
    };
}();