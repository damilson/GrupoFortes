alerta = function (Data) {
    if (Data.Sucesso) {
        $("#divAlerta").removeClass("alert-danger");
        $("#divAlerta").addClass("alert-success");
        $("#lblAlert").html("Sucesso");
        $("#msgAlert").html(Data.Mensagem);

    } else {
        $("#divAlerta").removeClass("alert-success");
        $("#divAlerta").addClass("alert-danger");
        $("#lblAlert").html("Falha");
        $("#msgAlert").html(Data.Mensagem);
    }
    $("#alerta").removeClass("hidden");
    setInterval(function () {
        $("#alerta").addClass("hidden");
    }, 5000);
}
