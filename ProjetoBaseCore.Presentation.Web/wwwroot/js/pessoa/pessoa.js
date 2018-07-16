$(function () {
    $('#btnSave').on('click', function () {
        CREATE.salvar();
    })
});

var CREATE = {
    salvar: function () {
        if (!$('#frmCreate').valid())
            return false;

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
    }
}