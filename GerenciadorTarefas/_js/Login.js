$(document).ready(function () {
    regiterValidators();
});

function regiterValidators() {
    //$('#btnLogin').bind("click", function () { btnLoginOnClick(); });

    $('#inputEmail').on('input', function () {
        var input = $(this);
        var re = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        var is_email = re.test(input.val());
        if (is_email) { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });

    $('#inputSenha').keyup(function (event) {
        var input = $(this);
        var message = $(this).val();
        if (message) { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });

}
/*
function btnLoginOnClick() {

    
    if (!isFormValid())
        return;
    

    var jsonUsuario = {        
        "Email": $('#inputEmail').val(),
        "Senha": $('#inputSenha').val()
    };

    $.ajax({
        type: "POST",
        url: "Login/ValidarLogin",        
        data: JSON.stringify(jsonUsuario),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            alert(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus);
        }

    });

}
*/

function isFormValid() {
    var element;
    var valid;
    var retorno = false;

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

    return true;
}