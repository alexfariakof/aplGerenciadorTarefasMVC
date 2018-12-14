$(document).ready(function () {
    regiterValidators();
});


function RegisterBtnSalvarOnClick() {
    ClearForm();
    $('#btnSalvar').unbind('click');
    $('#btnSalvar').bind("click", function () { btnSalvarOnClick(); });
}

function RegisterBtnAltualizarOnClick(id) {
    ClearForm();
    $('#inputTarefa').addClass("valid");
    $('#btnSalvar').unbind('click');



    var jsonTarefa = {
        "Id": id,
    };

    $.ajax({
        type: "POST",
        url: "Tarefa/GetTarefaById",
        data: JSON.stringify(jsonTarefa),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#inputTarefa').val(data.Titulo);

            $('#btnSalvar').bind("click", function () { btnAtualizarOnClick(id); });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus);
        }
    });
}


function RegisterBtnExcluirOnClick(id) {
    ClearForm();
    $('#btnSalvar').unbind('click');

    var jsonTarefa = {
        "Id": id,
    };

    $.ajax({
        type: "POST",
        url: "Tarefa/GetTarefaById",
        data: JSON.stringify(jsonTarefa),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#inputTarefa').val(data.Titulo);
            
            $('#btnSalvar').bind("click", function () { btnExcluirOnClick(id); });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus);
        }
    });
}

function btnSalvarOnClick() {

    if (!isFormValid())
        return;

    var jsonTarefa = {
        "Titulo": $('#inputTarefa').val(),
    };

    $.ajax({
        type: "POST",
        url: "Tarefa/SalvarTarefa",
        data: JSON.stringify(jsonTarefa),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            __doPostBack('Reload', '');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus);
        }

    });

}

function btnAtualizarOnClick(id) {
    if (!isFormValid())
        return;

    if (confirm('Deseja atualizar os dados')) {
        var jsonTarefa = {
            "Id": id,
            "Titulo": $('#inputTarefa').val(),
        };

        $.ajax({
            type: "POST",
            url: "Tarefa/AtualizarTarefa",
            data: JSON.stringify(jsonTarefa),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $('#tarefa' + id).css("background-color", "yellow");
                $('#tarefa' + id).css("text-decoration", "line-through");
                $.modal.close();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus);
            }

        });
    }
}

function btnExcluirOnClick(id) {
    if (confirm('Deseja Excluir os dados')) {
        var jsonTarefa = {
            "Id": id,
        };
        
        $.ajax({
            type: "POST",
            url: "Tarefa/ExcluirTarefa",
            data: JSON.stringify(jsonTarefa),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $('#tarefa' + id).css("background-color", "red");
                $('#tarefa' + id).css("text-decoration", "line-through");
                $.modal.close();                
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus);
            }

        });
    }
}

function regiterValidators() {
    
    $('#inputTarefa').keyup(function (event) {
        var input = $(this);
        var message = $(this).val();
        if (message) { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });

}

function ClearForm() {
    $('#inputTarefa').val('').removeClass();
    $(".msgValidacao").css('visibility', 'hidden');
}

function isFormValid() {
    var element;
    var valid;
    var retorno = false;
    element = $('#inputTarefa');
    valid = element.hasClass("valid");
    if (!valid) {
        $("#msgTarefa").css('visibility', 'visible');
        return false;
    }
    else {
        $("#msgTarefa").css('visibility', 'hidden');
    }

    return true;
}