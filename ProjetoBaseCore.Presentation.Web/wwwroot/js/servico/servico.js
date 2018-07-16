$(function () {
    $('#btnSave').on('click', function () {
        CREATE.salvar();
    })

    CREATE.carregarTabela();
});

var CREATE = {
    salvar: function () {
        if (!$('#frmCreate').valid())
            return false;

        var valor = $('#Valor').maskMoney('unmasked')[0];
        $('#ValorSemMascara').val(valor);
        var isEdit = parseInt($('#Id').val(), 0);
        $.ajax({
            type: 'Post',
            url: isEdit > 0 ? 'Edit' : 'Create',
            data: $('#frmCreate').serialize(),
            success: function (data, textStatus, xhr) {
                if (xhr.status === 200) {
                    alertSuccess("Dados atualizados!");
                }
            },
            error: function (data, textStatus, xhr) {
                alertError(xhr);
            }
        });
    },

    carregarTabela: function () {
        $("#tblServicos").DataTable({
            processing: true,
            destroy: true,
            paginate: true,
            language: {
                lengthMenu: 'Mostrando _MENU_ registros por página',
                zeroRecords: ' Nenhum registro foi encontrado.',
                info: '<h4>_DATA_ de _MAX_ encontrados</h4>',
                infoEmpty: '',
                infoFiltered: '',
                paginate: {
                    first: '←',
                    last: '→',
                    next: '»',
                    previous: '«'
                },
                thousands: '.',
                decimal: ','
            },
            autoWidth: false,
            lengthChange: false,
            searching: false,
            serverSide: true,
            //order: [4, "desc"],
            ajax: {
                "url": "/Servico/CarregarTabela",
                "type": "POST",
                "datatype": "json"
            },
            "columns": [
                { "data": "Descricao", "name": "Descricao", "title": "Descrição", "autoWidth": true },
                { "data": "PessoaFormatado", "name": "Pessoa", "title": "Pessoa", "autoWidth": true, "sortable": false },
                { "data": "TipoMovimentacaoFormatado", "name": "TipoMovimentacao", "title": "Débito/Crédito", "autoWidth": true },
                { "data": "NaturezaFormatado", "name": "Natureza", "title": "Dinheiro/Cheque", "autoWidth": true },
                { "data": "DataFormatado", "name": "Data", "title": "Data", "autoWidth": true },
                { "data": "ValorFormatado", "name": "Valor", "title": "Valor", "autoWidth": true },
            ],
            //"rowCallback": function (row, data, index) {
            //    $('#hddnSaldo').val(data.Saldo);
            //    if (data.TipoMovimentacaoFormatado == "Crédito") {
            //        $('td', row).css('color', '#ff4d4d');
            //    }
            //    else if (data.TipoMovimentacaoFormatado == "Débito") {
            //        $('td', row).css('color', 'green');
            //    }
            //    $('#txtDataDe').val("");
            //    $('#txtDataAte').val("");
            //}
        });
    }
}