$(document).ready(function () {

    $("#txtEmail").blur(function () {
        // Expresion regular para validar el correo
        var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
        // Se utiliza la funcion test() nativa de JavaScript
        if (!regex.test($('#txtEmail').val().trim())) {
            $("#txtEmail").parent().attr('class', 'col-md-6 has-error has-feedback');
            $('#spntxtEmail').attr('class', 'text-danger');
        } else {
            $("#txtEmail").parent().attr('class', 'col-md-6 has-success has-feedback');
            $('#spntxtEmail').attr('class', 'text-success');
        }
    });

    $('#SelReportService').change(function () {
        loadReport($(this).val());
    });


});

function validador() {
    var respuesta = true;
    $("[id^=txt]").each(function () {
        if ($(this).val() == "" && $(this).attr("required") == "required") {
            respuesta = false;
            var elmntid = $(this).attr("id")
            $('#spn' + elmntid).html("Ingrese datos , este campo no debe estar vacío");
        } else {
            var elmntid = $(this).attr("id")
            $('#spn' + elmntid).html("");
        }
        if (~$(this).attr("class").indexOf("numericVal")) {
            if (isNaN($(this).val()) || $(this).val() < 0 || $(this).val() == "") {
                respuesta = false;
                var elmntid = $(this).attr("id")
                $('#spn' + elmntid).html("Ingrese un valor numérico mayor a 0");
            } else {
                var elmntid = $(this).attr("id")
                $('#spn' + elmntid).html("");
            }
        }
    });
    return respuesta;
}

function EvaluateService() {
    if (validador()) {
        var form = $("#frmEvaluation");
        $.ajax({
            url: form.attr('action'),
            data: form.serialize(),
            type: "POST",
            cache: false,
            success: function (data, textStatus, jqXHR) {
                if (data.msj != null) {
                    $('#MsjTitleAlert').html('Evaluación');
                    $('#MsjBodyAlert').html(data.msj);
                    $('#AlertModal').modal('toggle');
                    
                } else {
                    $('#MsjTitleAlert').html('Evaluación');
                    $('#MsjBodyAlert').html("Registro correcto");
                    $('#AlertModal').modal('toggle');
                    $('#contentall').html(data);
                   
                }
            },
            error: function (req, status, error) {
            }
        });
    } else {
        return false;
    }

}

function loadReport(vIdService) {
    $.ajax({
        url: '../Home/getReport',
        data: {
            idService: vIdService,
        },
            type: "POST",
            cache: false,
            success: function (data, textStatus, jqXHR) {
                if (data.msj != null) {
                    $('#MsjTitleAlert').html('Evaluación');
                    $('#MsjBodyAlert').html(data.msj);
                    $('#AlertModal').modal('toggle');

                } else {
                    $('#divEval').html(data);

                }
            },
            error: function (req, status, error) {
            }
        });
}