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
                cols += '<button onclick="removeTableRow(this)" type="button" class="btn btn-danger">Remover</button>';
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

removeTableRow = function (item) {
    var tr = $(item).closest('tr');

    tr.fadeOut(400, function () {
        tr.remove();
    });

    return false;
}
