// Función para serializar formularios a objetos json
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
}

/* Application controller before page loaded
------------------------------------------------ */
var PreApp = function () {
    "use strict";
    return {
        init: function () {
            this.preHandleKendoCulture();
        },

        preHandleKendoCulture: function () {
            console.log("((preHandleKendoCulture))");
            kendo.culture("es-CO");
            
            kendo.cultures["es-CO"] = {
                name: "es-CO",
                numberFormat: {
                    pattern: ["-n"],
                    decimals: 2,
                    ".": ".",
                    ".": ".",
                    groupSize: [3],
                    percent: {
                        pattern: ["-n%", "n%"],
                        decimals: 2,
                        ".": ".",
                        ",": ",",
                        groupSize: [3],
                        symbol: "%"
                    },
                    currency: {
                        name: "Colombian Peso",
                        abbr: "COP",
                        pattern: ["-$n", "$n"],
                        decimals: 2,
                        ",": ".",
                        ".": ",",
                        groupSize: [3],
                        symbol: "$"
                    }
                },
                calendars: {
                    standard: {
                        days: {
                            names: ["domingo", "lunes", "martes", "miércoles", "jueves", "viernes", "sábado"],
                            namesAbbr: ["dom.", "lun.", "mar.", "mié.", "jue.", "vie.", "sáb."],
                            namesShort: ["do.", "lu.", "ma.", "mi.", "ju.", "vi.", "sá."]
                        },
                        months: {
                            names: ["enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"],
                            namesAbbr: ["ene.", "feb.", "mar.", "abr.", "may.", "jun.", "jul.", "ago.", "sep.", "oct.", "nov.", "dic."]
                        },
                        AM: ["a. m.", "a. m.", "A. M."],
                        PM: ["p. m.", "p. m.", "P. M."],
                        patterns: {
                            d: "dd/MM/yyyy",
                            D: "dddd, dd' de 'MMMM' de 'yyyy",
                            F: "dddd, dd' de 'MMMM' de 'yyyy h:mm:ss tt",
                            g: "dd/MM/yyyy h:mm tt",
                            G: "dd/MM/yyyy h:mm:ss tt",
                            m: "d' de 'MMMM",
                            M: "d' de 'MMMM",
                            s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                            t: "h:mm tt",
                            T: "h:mm:ss tt",
                            u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                            y: "MMMM' de 'yyyy",
                            Y: "MMMM' de 'yyyy"
                        },
                        "/": "/",
                        ":": ":",
                        firstDay: 1
                    }
                }
            }

        }
    };
}();

/* Utils
------------------------------------------------ */
var Utils = function () {
    "use strict";
    return {
        init: function () {

        },

        onFilterMenuInit: function (e) {
           
            var ddl1 = e.container.find("select:eq(0)").data("kendoDropDownList");                
            setTimeout(function () {
                //ddl1.wrapper.hide();
            });
           

            try {
                var ddl2 = e.container.find("select:eq(1)").data("kendoDropDownList");

                // aplica en caso de que el segundo filtro exista, habilitado unicamente para fechas
                var ddl3 = e.container.find("select:eq(2)").data("kendoDropDownList");
                ddl3.value('lte');
                ddl3.trigger('change');

                setTimeout(function () {
                    ddl2.wrapper.hide();
                    //ddl3.wrapper.hide();
                });
            } catch (e) {
                // en caso de falla significa que no tiene segundo filtro
            }
        },

        onModelStateError: function (e, status) {
            if (e.errors) {
                var message = "";

                $.each(e.errors, function (key, value) {
                    if (value.errors) {
                        message += value.errors.join("\n");
                    }
                });
                toastr.error(message, "Error");
            }
        },

        // Adiciona item a un kendogrid
        addGridDataItem: function (targetId, dataItem) {
            var grid = $(targetId).data("kendoGrid");
            grid.dataSource.add(dataItem);
        },

        // Elimina item de un kendogrid 
        removeGridDataItem: function (e, targetId) {
            e.preventDefault();
            var grid = $(targetId).data("kendoGrid");
            var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
            grid.dataSource.remove(dataItem);
        },

        // Retorna lista de items de un kendogrid 
        getGridDataSource: function (targetId) {
            var grid = $(targetId).data("kendoGrid");
            var jsonData = jQuery.parseJSON(JSON.stringify(grid.dataSource.data()));
            return jsonData;
        },

        // Retorna item de un kendogrid
        getGridDataItem: function (e, targetId) {
            e.preventDefault();
            var grid = $(targetId).data("kendoGrid");
            var dataItem = grid.dataItem($(e.currentTarget).closest("tr"));
            return dataItem;
        },

        // Actualiza contenido de un kendogrid con un objeto javascript
        setGridDataSource: function (targetId, jsonData) {
            var grid = $(targetId).data("kendoGrid");
            grid.dataSource.data(jsonData);
        },

        // Muestra modal pricipal
        // - path: direccion url de vista modal
        // - dataModalValue: tamaño del modal ("", "modal-lg", "modal-xl")
        // - params: objecto javascript con parametros para enviar
        // - modalName: NOTA: sera unicamente usado por la función "showModalBs2" y sirve para especificar que se abrira un modal secundario
        showModalBs: function (path, dataModalValue, params, modalName) {
            dataModalValue = typeof dataModalValue !== 'undefined' ? dataModalValue : ""; //default value
            modalName = typeof modalName !== 'undefined' ? modalName : "modal"; // default values

            if (typeof params !== 'undefined' && params != null) {
                params = "?" + $.param(params);
            } else {
                params = "";
            }

            var currentModal = (modalName == "modal") ? modalBs :
                (modalName == "modal2") ? modalBs2 : null;
            var modalContent = currentModal.find(".modal-content");
            var url = path + params;

            modalContent.load(url, function (response, status, xhr) {
                switch (status) {
                    case "success":
                        currentModal.modal({ backdrop: 'static', keyboard: false }, 'show');

                        if (dataModalValue == "modal-lg") {
                            currentModal.find(".modal-dialog").addClass("modal-lg");
                        }
                        else if (dataModalValue == "modal-xl") {
                            currentModal.find(".modal-dialog").addClass("modal-xl");
                        }
                        else {
                            currentModal.find(".modal-dialog").removeClass("modal-lg");
                            currentModal.find(".modal-dialog").removeClass("modal-xl");
                        }

                        // Intercepta links para salto a otras paginas
                        handleLoadingOnLinks();

                        // Activa los place holder de los campos
                        handleEnablePlaceholder();

                        // Inicializa el popup v1
                        try {
                            onModalInit();
                        } catch (ex) { }

                        // Configura links existentes en segundo modal
                        if (modalName != "modal2") {
                            handleAjaxModal();
                        }

                        break;

                    case "error":
                        var message = "Error de ejecución: " + xhr.status + " " + xhr.statusText;
                        if (xhr.status == 403) $.msgbox(response, { type: 'error' });
                        else $.msgbox(message, { type: 'error' });
                        break;
                }
            });
        },

        // Muestra modal secundario
        // - path: direccion url de vista modal
        // - dataModalValue: tamaño del modal ("", "modal-lg", "modal-xl")
        // - params: objecto javascript con parametros para enviar
        showModalBs2: function (path, dataModalValue, params) {
            this.showModalBs(path, dataModalValue, params, "modal2");
        },

        // Remplaza los parametros de listas por dropdowns para una selección
        createSingleSelectEditor: function(placeholder, options) {
            var dropDownElement = $(placeholder).html('<div></div>');
            var parameter,
                valueChangedCallback = options.parameterChanged,
                dropDownList;

            function onChange() {
                var val = dropDownList.value();
                valueChangedCallback(parameter, val);
            }

            return {
                beginEdit: function (param) {

                    parameter = param;

                    $(dropDownElement).kendoDropDownList({
                        dataTextField: "name",
                        dataValueField: "value",
                        value: parameter.value,
                        dataSource: parameter.availableValues,
                        change: onChange,
                        filter: "contains"
                    });

                    dropDownList = $(dropDownElement).data("kendoDropDownList");
                }
            };
        }
    };
}();


