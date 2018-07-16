function alertSuccess(mensagem) {
    var dialog = bootbox.dialog({
        title: '<span class="glyphicon glyphicon-ok-sign icon-success"></span> Sucesso !',
        message: mensagem ? "<p>"+ mensagem +"<p>" : "<p>Registro salvo com Sucesso!</p> ",
        buttons: {
            confirm: {
                label: 'OK',
                className: 'btn-success'
            },
        }
    });
}

function alertDelete() {
    var dialog = bootbox.dialog({
        title: '<span class="glyphicon glyphicon-ok-sign icon-success"></span> Sucesso !',
        message: "<p>Registro excluído com Sucesso!</p>",
        buttons: {
            confirm: {
                label: 'OK',
                className: 'btn-success'
            },
        }
    });
}

function alertConfirm(callback, param) {
    bootbox.confirm({
        message: "Confirma a operação?",
        buttons: {
            confirm: {
                label: 'Sim',
                className: 'btn-success'
            },
            cancel: {
                label: 'Não',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result)
                callback(param);
        }
    });
}

function alertError(mensagemErro) {
    var dialog = bootbox.dialog({
        title: '<span class="glyphicon glyphicon-remove-sign icon-error"></span> Erro !',
        message: "<p>Houve um erro interno no sistema, informe ao administrador a seguinte mensagem:</p><br>" + mensagemErro,
        buttons: {
            confirm: {
                label: 'OK',
                className: 'btn-success'
            },
        }
    });
}

function alertCustom(mensagem) {
    var dialog = bootbox.dialog({
        title: '<span class="glyphicon glyphicon-info-sign icon-info"></span> Informação !',
        message: mensagem,
        buttons: {
            confirm: {
                label: 'OK',
                className: 'btn-success'
            },
        }
    });
}