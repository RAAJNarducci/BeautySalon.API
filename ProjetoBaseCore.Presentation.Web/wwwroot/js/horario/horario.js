$(function () {
});

var CREATE = {
    confirmarHorarios: function () {
        arrayHorarios = [];
        horario = {}; 
        var horarios = $('.cbHorarios');
        $.each(horarios, function (i, v) {
            if ($('#' + v.id).is(':checked')) {
                horario = {
                    Id: v.value,
                    Ativo: true,
                    Descricao: null,
                };
            }
            else {
                horario = {
                    Id: v.value,
                    Ativo: false,
                    Descricao: null,
                };
            }
            arrayHorarios.push(horario);
        })
        if (arrayHorarios.length > 0) {
            CREATE.salvar(arrayHorarios);
        }
    },
    salvar: function (arrayHorarios) {
        $.ajax({
            type: 'POST',
            url: 'Horario/Edit',
            data: {
                horariosViewModel: arrayHorarios
            },
            success: function (data, textStatus, xhr) {
                if (xhr.status === 200) {
                    alertSuccess("Dados atualizados!");
                }
            },
            error: function (data, textStatus, xhr) {
                alertError(xhr);
            }
        });
    }
}