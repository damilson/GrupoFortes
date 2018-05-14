using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GrupoFortes.Entidades.Model;
using GrupoFortes.Entidades.ValidaModel;
using GrupoFortes.Repositorio.Repositorio;

namespace GrupoFortes.Core
{
    public class PedidoCore : IPedidoCore
    {
        private readonly IRepositorio _repositorio;

        public PedidoCore(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Pedido Buscar(int id)
        {
            return _repositorio.Find<Pedido>(x => x.PedidoId == id);
        }

        public void Deletar(int id)
        {
            var pedido = _repositorio.Find<Pedido>(x => x.PedidoId == id);

            pedido.deletado = true;
            _repositorio.UpdateAndSaveChanges(pedido);
        }

        public void Editar(Pedido pedido)
        {
            var pedidoAlterado = _repositorio.Find<Pedido>(x => x.PedidoId == pedido.PedidoId);

            var listaItens = new List<Item>();
            foreach (var item in pedido.Itens)
            {
                item.Produto = _repositorio.Find<Produto>(x => x.CodigoProduto == item.Produto.CodigoProduto);
                listaItens.Add(item);
            }

            pedido.Itens = listaItens;

            //pedido.Itens.ForEach(x => _repositorio.GetContext().Entry(x).State = EntityState.Modified);

            var pedidosAExcluir = pedidoAlterado.Itens.Except(pedido.Itens).ToList();
            var pedidosAInserir = pedido.Itens.Except(pedidoAlterado.Itens).ToList();

            foreach (var excluir in pedidosAExcluir)
            {
                _repositorio.DeleteAndSaveChanges<Item>(x => x.ItemId == excluir.ItemId);
            }

            foreach (var incluir in pedidosAInserir)
            {
                incluir.Pedido = pedidoAlterado;
                _repositorio.InsertAndSaveChanges(incluir);
            }

            //pedidoAlterado.Itens = pedido.Itens;
            pedidoAlterado.QuantidadeDeProdutos = pedido.QuantidadeDeProdutos;
            pedidoAlterado.ValorTotalDoPedido = pedido.ValorTotalDoPedido;

            _repositorio.UpdateAndSaveChanges(pedidoAlterado);
        }

        public List<Pedido> Listar(int idFornecedor = 0)
        {
            var pedidos = _repositorio.List<Pedido>().Where(x => !x.deletado);

            if(idFornecedor != 0)
            {
                pedidos = pedidos.Where(x => x.Fornecedor.FornecedorId == idFornecedor);
            }

            return pedidos.ToList();
        }

        public void Salvar(Pedido pedido)
        {
            var listaItens = new List<Item>();
            pedido.Fornecedor = _repositorio.Find<Fornecedor>(x => x.FornecedorId == pedido.Fornecedor.FornecedorId);
            foreach (var item in pedido.Itens)
            {
                item.Produto = _repositorio.Find<Produto>(x => x.CodigoProduto == item.Produto.CodigoProduto);
                listaItens.Add(item);
            }

            pedido.Itens = listaItens;

            _repositorio.InsertAndSaveChanges(pedido);
        }
    }
}
