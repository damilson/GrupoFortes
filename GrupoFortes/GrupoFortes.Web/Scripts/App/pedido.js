cadastrarPedido = function () {
    $.blockUI({ message: '<h4><img src="../Content/Imagens/busy.gif" /> Aguarde um momento...</h4>' });
    $.post("/Pedido/CreateView",
        function (view) {
            $("#divModals").html(view);
            $("#myModalCadastroPedido").modal({ backdrop: "static" });
            $.unblockUI();
        });
}

cancelarCadastro = function () {
    $("#myModalCadastroPedido").modal("hide");
}

AddTableRow = function () {

    var statusData = false;
    $.post("/Produto/Produto",
        { codigo: $("#CodigoDoProduto").val() },
        dataType: 'json',
        async: false,
        function (Data) {
            if (Data != null) {
                    
                $("#DescricaoDoProduto").val(Data.Descricao);
                var newRow = $("<tr>");
                var cols = "";

                cols += '<td>' + Data.Descricao + '</td>';
                cols += '<td>' + Data.CodigoProduto + '</td>';
                cols += '<td>' + $("#QuantidadeProduto").val() + '</td>';
                cols += '<td>' + Data.ValordoProduto * + '</td>';
                cols += '<td>';
                cols += '<button onclick="RemoveTableRow(this)" type="button" class="btn btn-danger">Remover</button>';
                cols += '</td>';

                newRow.append(cols);
                $("#products-table").append(newRow);

                statusData = true;

                return false;
            }
        })
    if (!statusData) {
        var Data = { Mensagem: "Pedido não cadastrado", Sucesso: false }
        alerta(Data);
    }
};
