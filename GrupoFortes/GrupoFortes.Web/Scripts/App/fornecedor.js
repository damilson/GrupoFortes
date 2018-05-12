cadastraFornecedor = function () {
    $.blockUI({ message: '<h4><img src="../Content/Imagens/busy.gif" /> Aguarde um momento...</h4>' });     
    $.post("/Fornecedor/CreateView",
        function (view) {
            $("#divModals").html(view);
            $("#myModalCadastroFornecedor").modal({ backdrop: "static" });
            $.unblockUI();
        });
}

cancelarCadastro = function () {
    $("#myModalCadastroFornecedor").modal("hide");
}

editarFornecedor = function (Id) {
    $.blockUI({ message: '<h4><img src="../Content/Imagens/busy.gif" /> Aguarde um momento...</h4>' });
    $.post("/Fornecedor/EditView",
        { id: Id },
        function (view) {
            $("#divModals").html(view);
            $("#myModalEditarFornecedor").modal({ backdrop: "static" });
            $.unblockUI();
        });
}

cancelarEdicao = function () {
    $("#myModalEditarFornecedor").modal("hide");
}

detalharFornecedor = function (Id) {
    $.blockUI({ message: '<h4><img src="../Content/Imagens/busy.gif" /> Aguarde um momento...</h4>' });
    $.post("/Fornecedor/Details",
        { id: Id },
        function (view) {
            $("#divModals").html(view);
            $("#myModalDetalheFornecedor").modal({ backdrop: "static" });
            $.unblockUI();
        });
}

okDetalhe = function () {
    $("#myModalDetalheFornecedor").modal("hide");
}
sucessoAoCadastrarFornecedor = function (Data) {
    alerta(Data);
    if (Data.Sucesso) {
        $.post("/Fornecedor/Tabela",
            function (view) {
                $("#tabela").html(view);
            });
        $("#myModalCadastroFornecedor").modal("hide");
    }
}

sucessoAoEditarFornecedor = function (Data) {
    alerta(Data);
    if (Data.Sucesso) {
        $.post("/Fornecedor/Tabela",
            function (view) {
                $("#tabela").html(view);
            });
        $("#myModalCadastroFornecedor").modal("hide");
    }
}

deletarFornecedor = function (Id) {
    bootbox.confirm({
        message: "Deseja realmente excluir o fornecedor?",
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
                $.post("/Fornecedor/Delete",
                    { Id: Id },
                    function (Data) {
                        if (Data.Sucesso) {
                            alerta(Data);
                            $.post("/Fornecedor/Tabela", function (view) {
                                $("#tabela").html(view);
                            });
                        }
                    }
                )
            }
        }
    })
};
