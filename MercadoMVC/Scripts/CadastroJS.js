window.setTimeout(function () {//funcao para deixar tempo na mensagem
    $(".alert").fadeTo(500, 0).slideUp(500, function () {
        $(this).remove();
    });
}, 4000);