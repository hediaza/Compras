
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

        handleValidator: function(){
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
        }
        
    }
}();



