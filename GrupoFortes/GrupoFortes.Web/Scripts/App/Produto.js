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

sucessoAoEditarProduto = function (Data) {
    alerta(Data);
    if (Data.Sucesso) {
        $.post("/Produto/Tabela",
            function (view) {
                $("#tabela").html(view);
            });
        $("#myModalEditarProduto").modal("hide");
    }
}

cancelarEdicao = function () {
    $("#myModalEditarProduto").modal("hide");
}

ok = function () {        
    $("#myModalDetalharProduto").modal("hide");
}

editarProduto = function (id) {
    $.blockUI({ message: '<h4><img src="../Content/Imagens/busy.gif" /> Aguarde um momento...</h4>' });
    $.post("/Produto/EditView",
        {id : id},
        function (view) {
            $("#divModals").html(view);
            $("#myModalEditarProduto").modal({ backdrop: "static" });
            $.unblockUI();
        });
}

detalharProduto = function (id) {
    $.blockUI({ message: '<h4><img src="../Content/Imagens/busy.gif" /> Aguarde um momento...</h4>' });
    $.post("/Produto/Details",
        { id: id },
        function (view) {
            $("#divModals").html(view);
            $("#myModalDetalharProduto").modal({ backdrop: "static" });
            $.unblockUI();
        });
}


deletarProduto = function (Id) {
    bootbox.confirm({
        message: "Deseja realmente excluir o Produto?",
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
            if (result) {
                $.post("/Produto/Delete",
                    { id: Id },
                    function (Data) {
                        if (Data.Sucesso) {
                            alerta(Data);
                            $.post("/Produto/Tabela", function (view) {
                                $("#tabela").html(view);
                            });
                        }
                    }
                )
            }
        }
    })
};
