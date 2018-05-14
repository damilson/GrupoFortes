$(document).ready(function () {
    $("#FornecedorIdFiltro").change(function () {
        $.post("/Pedido/Tabela",
            { idFornecedor: $("#FornecedorIdFiltro :selected").val() },
            function (view) {
                $("#tabela").html(view);
            }
        )
    })
})

var editar = false;

cadastrarPedido = function () {
    $.blockUI({ message: '<h4><img src="../Content/Imagens/busy.gif" /> Aguarde um momento...</h4>' });
    $.post("/Pedido/CreateView",
        function (view) {
            $("#divModals").html(view);
            $("#myModalCadastroPedido").modal({ backdrop: "static" });
            $.unblockUI();
        });
    editar = false;
}

cancelarCadastro = function () {
    $("#myModalCadastroPedido").modal("hide");
}

ok = function () {
    $("#myModalDetalhesPedido").modal("hide");
}

AddTableRow = function () {
    var statusData = false;
    $.post("/Produto/Produto",
        { codigo: $("#CodigoDoProduto").val() },
        function (Data) {
            if (Data != null) {

                var valor = Data.ValordoProduto * $("#QuantidadeProduto").val();
                $("#DescricaoDoProduto").val(Data.Descricao);
                var newRow = $("<tr>");
                var cols = "";

                if (editar) {
                    cols += '<td>' + Data.ItemId + '</td>';
                }
                cols += '<td>' + Data.Descricao + '</td>';
                cols += '<td>' + Data.CodigoProduto + '</td>';
                cols += '<td class="qtdItens">' + $("#QuantidadeProduto").val() + '</td>';
                cols += '<td>' + Data.ValordoProduto.toFixed(2) + '</td>';
                cols += '<td class="valor-calculado">' + valor.toFixed(2) + '</td>';
                cols += '<td>';
                cols += '<button onclick="removeTableRow(this)" type="button" class="btn btn-danger">Remover</button>';
                cols += '</td>';

                newRow.append(cols);
                $("#products-table").append(newRow);

                calculaTotal();
                calculaItens();

                return false;
            };
        })
}

removeTableRow = function (item) {
    var tr = $(item).closest('tr');

    tr.fadeOut(400, function () {
        tr.remove();
        calculaTotal();
        calculaItens();
    });

    return false;
}

calculaItens = function () {
    var totalItens = 0;

    $(".qtdItens").each(function () {
        totalItens += parseInt($(this).text());
    });
    $("#qtd").text(totalItens);
}

calculaTotal = function () {
    var valorCalculado = 0;

    $(".valor-calculado").each(function () {
        valorCalculado += parseFloat($(this).text());
    });
    $("#qtdtotal").text(valorCalculado.toFixed(2));
}

salvarPedido = function () {
    var pedidos = new Array;
    var quantidadeItens = 0;
    var valorTotalCalculado = 0;
    $('#products-table tbody tr').each(function () {
        var colunas = $(this).children();
        var pedido = {
            'Quantidade': $(colunas[2]).text(),
            'Produto': {
                CodigoProduto: $(colunas[1]).text(),
                Descricao: $(colunas[0]).text(),
            }
        };

        pedidos.push(pedido);
    });

    $(".qtdItens").each(function () {
        quantidadeItens += parseInt($(this).text());
    });

    $(".valor-calculado").each(function () {
        valorTotalCalculado += parseFloat($(this).text());
    });

    $.post("/Pedido/Create",
        {
            model: {
                CodigoDoPedido: $("#CodigoDoPedido").val(),
                FornecedorId: $("#FornecedorId :selected").val(),
                Itens: pedidos,
                QuantidadeDeProdutos: quantidadeItens,
                ValorTotalDoPedido: valorTotalCalculado
            }
        },
        function (Data) {
            if (Data.Sucesso) {
                alerta(Data);
                $.post("/Pedido/Tabela", function (view) {
                    $("#tabela").html(view);
                    $("#myModalCadastroPedido").modal("hide");
                });
            }
        })
}

detalharPedido = function (id) {
    $.blockUI({ message: '<h4><img src="../Content/Imagens/busy.gif" /> Aguarde um momento...</h4>' });
    $.post("/Pedido/Details",
        { id: id },
        function (view) {
            $("#divModals").html(view);
            $("#myModalDetalhesPedido").modal({ backdrop: "static" });
            $.unblockUI();
        });
}

editarPedidoView = function (id) {
    $.blockUI({ message: '<h4><img src="../Content/Imagens/busy.gif" /> Aguarde um momento...</h4>' });
    $.post("/Pedido/EditView",
        { id: id },
        function (view) {
            $("#divModals").html(view);
            $("#myModalEditarPedido").modal({ backdrop: "static" });
            $.unblockUI();
        });
    editar = true;
}

editarPedido = function () {
    var pedidos = new Array;
    var quantidadeItens = 0;
    var valorTotalCalculado = 0;
    $('#products-table tbody tr').each(function () {
        var colunas = $(this).children();
        var pedido = {
            'ItemId': $(colunas[0]).text(),
            'Quantidade': $(colunas[3]).text(),
            'Produto': {
                CodigoProduto: $(colunas[2]).text(),
                Descricao: $(colunas[1]).text(),
            }
        };

        pedidos.push(pedido);
    });

    $(".qtdItens").each(function () {
        quantidadeItens += parseInt($(this).text());
    });

    $(".valor-calculado").each(function () {
        valorTotalCalculado += parseFloat($(this).text());
    });

    $.post("/Pedido/Edit",
        {
            model: {
                PedidoId: $("#PedidoId").val(),
                CodigoDoPedido: $("#CodigoDoPedido").val(),
                FornecedorId: $("#FornecedorId :selected").val(),
                Itens: pedidos,
                QuantidadeDeProdutos: quantidadeItens,
                ValorTotalDoPedido: valorTotalCalculado
            }
        },
        function (Data) {
            if (Data.Sucesso) {
                alerta(Data);
                $.post("/Pedido/Tabela", function (view) {
                    $("#tabela").html(view);
                    $("#myModalEditarPedido").modal("hide");
                });
            }
        })
}

cancelarEdicao = function () {
    $("#myModalEditarPedido").modal("hide");
}

deletarPedido = function (Id) {
    bootbox.confirm({
        message: "Deseja realmente excluir o Pedido?",
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
                $.post("/Pedido/Delete",
                    { id: Id },
                    function (Data) {
                        if (Data.Sucesso) {
                            alerta(Data);
                            $.post("/Pedido/Tabela", function (view) {
                                $("#tabela").html(view);
                            });
                        }
                    }
                )
            }
        }
    })
}

