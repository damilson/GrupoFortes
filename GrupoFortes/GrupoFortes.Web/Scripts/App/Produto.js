cadastraProduto = function () {
    $.blockUI({ message: '<h4><img src="../Content/Imagens/busy.gif" /> Aguarde um momento...</h4>' });
    $.post("/Produto/CreateView",
        function (view) {
            $("#divModals").html(view);
            $("#myModalCadastroProduto").modal({ backdrop: "static" });
            $.unblockUI();
        });
}

cancelarCadastro = function () {
    $("#myModalCadastroProduto").modal("hide");
}

sucessoAoCadastrarProduto = function (Data) {
    alerta(Data);
    if (Data.Sucesso) {
        $.post("/Produto/Tabela",
            function (view) {
                $("#tabela").html(view);
            });
        $("#myModalCadastroProduto").modal("hide");
    }
}
