$(document).ready(function () {
    regiterValidators();
});

function RegisterBtnAltualizarOnClick(id, e) {
    ClearForm();
    $('#inputNome').addClass("valid");
    $('#inputEmail').addClass("valid");
    $('#inputSenha').addClass("valid");
    $('#inputConfirmaSenha').addClass("valid");
    $('#btnSalvar').unbind('click');
    $(".divSenha").css('visibility', 'visible');


    var jsonUsuario = {
        "Id": id,
    };

    $.ajax({
        type: "POST",
        url: "Usuario/GetUsuarioById",
        data: JSON.stringify(jsonUsuario),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#inputNome').val(data.Nome);
            $('#inputEmail').val(data.Email);
            $('#dropPermissao').val(data.Permissao.Id);
            $('#inputSenha').val(data.Senha);
            $('#inputConfirmaSenha').val(data.Senha);
            $('#myModal').modal('show');
            regiterValidators();
            $('#btnSalvar').bind("click", function () { btnAtualizarOnClick(id, e); });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus);
        }
    });

}


function RegisterBtnSalvarOnClick() {
    ClearForm();
    $(".divSenha").css('visibility', 'visible');

    $('#btnSalvar').unbind('click');
    $('#btnSalvar').bind("click", function () { btnSalvarOnClick(); } );
}


function RegisterBtnExcluirOnClick(id) {
    ClearForm();
    $('#btnSalvar').unbind('click');
    $(".divSenha").css('visibility', 'hidden');

    var jsonUsuario = {
        "Id": id,
    };

    $.ajax({
        type: "POST",
        url: "Usuario/GetUsuarioById",
        data: JSON.stringify(jsonUsuario),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#inputNome').val(data.Nome);
            $('#inputEmail').val(data.Email);
            $('#dropPermissao').val(data.IdPermissao);


            $('#btnSalvar').bind( "click", function () { btnExcluirOnClick(id); });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus);
        }
    });

    
}

function btnSalvarOnClick() {

    if (!isFormValid()) 
        return;

        var jsonUsuario = {
            "Nome": $('#inputNome').val(),
            "Email": $('#inputEmail').val(),
            "IdPermissao": $('#dropPermissao').val(),
            "Senha": $('#inputSenha').val()
        };

        $.ajax({
            type: "POST",
            url: "Usuario/SalvarUsuario",
            data: JSON.stringify(jsonUsuario),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data != true)
                    $('#myModal').modal('hide');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus);
            }

        });
}

function btnAtualizarOnClick(id, row ) {
    if (!isFormValid())
        return;

    if (confirm('Deseja atualizar os dados')) {
        var jsonUsuario = {
            "Id": id,
            "Nome": $('#inputNome').val(),
            "Email": $('#inputEmail').val(),
            "IdPermissao": $('#dropPermissao').val(),
            "Senha": $('#inputSenha').val()
        };

        $.ajax({
            type: "POST",
            url: "Usuario/AtualizarUsuario",
            data: JSON.stringify(jsonUsuario),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data === true) {
                    $(row, '.row').parent().children().css("background-color", "yellow");
                    $(row, '.row').parent().children().css("text-decoration", "line-through");
                    $('#myModal').modal('hide');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus);
            }

        });
    }
}

function btnExcluirOnClick(id) {
    if (confirm('Deseja excluir os dados')) {
        var jsonUsuario = {
            "Id": id,
        };


        $.ajax({
            type: "POST",
            url: "Usuario/ExcluirUsuario",
            data: JSON.stringify(jsonUsuario),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data === true) {
                    $(row, '.row').parent().children().css("background-color", "yellow");
                    $(row, '.row').parent().children().css("text-decoration", "line-through");
                    $('#myModal').modal('hide');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus);
            }

        });
    }
}

function regiterValidators() {
    $('#inputEmail').on('input', function () {
        var input = $(this);
        var re = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        var is_email = re.test(input.val());
        if (is_email) { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });


    $('#inputNome').keyup(function (event) {
        var input = $(this);
        var message = $(this).val();
        if (message) { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });

    $('#inputSenha').keyup(function (event) {
        var input = $(this);
        var message = $(this).val();
        if (message) { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });

    $('#inputConfirmaSenha').keyup(function (event) {
        var input = $(this);
        var message = $(this).val();
        
        if ($('#inputSenha').val() == $('#inputConfirmaSenha').val())
        { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });

}

function ClearForm() {
    $('#inputNome').val('').removeClass();
    $('#inputEmail').val('').removeClass();
    $('#dropPermissao').val(1).removeClass();
    $('#inputSenha').val('').removeClass();
    $('#inputConfirmaSenha').val('').removeClass();
    $(".msgValidacao").css('visibility', 'hidden');
}

function isFormValid() {
    var element;
    var valid;
    var retorno = false;
    element = $('#inputNome');
    valid = element.hasClass("valid");
    if (!valid) {
        $("#msgNome").css('visibility', 'visible');
        return false;
    }
    else {
        $("#msgNome").css('visibility', 'hidden');
    }

    element = $('#inputEmail');
    valid = element.hasClass("valid");
    if (!valid) {
        $("#msgEmail").css('visibility', 'visible');
        return false;
    }
    else {
        $("#msgEmail").css('visibility', 'hidden');
    }

    element = $('#inputSenha');
    valid = element.hasClass("valid");
    if (!valid) {
        $("#msgSenha").css('visibility', 'visible');
        return false;
    }
    else { 
        $("#msgSenha").css('visibility', 'hidden');
    }


    element = $('#inputConfirmaSenha');
    valid = element.hasClass("valid");
    if (!valid) {
        $("#msgConfirmaSenha").css('visibility', 'visible');
        return false;
    }
    else {
        $("#msgConfirmaSenha").css('visibility', 'hidden');
    }
    return true;
}


