$(function () {
    $('.mask-cpf').inputmask({ mask: "999.999.999-99", placeholder: '' });
    $('.mask-cep').inputmask({ mask: "99999-999", placeholder: '' });
    $('.mask-number').inputmask({ mask: "99999", placeholder: '' });
    $('.mask-date').inputmask({ mask: "99/99/9999", placeholder: '' });
    $('.mask-phone').inputmask({ mask: "(99) 9999[9]-9999", placeholder: '' });
    $(".mask-money").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',' });
});