using System.Collections.Generic;
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
            _repositorio.DeleteAndSaveChanges<Pedido>(x => x.PedidoId == id);
        }

        public void Editar(Pedido pedido)
        {
            var pedidoAlterado = _repositorio.Find<Pedido>(x => x.PedidoId == pedido.PedidoId);

            pedidoAlterado.QuantidadeDeProdutos = pedido.QuantidadeDeProdutos;
            pedidoAlterado.ValorTotalDoPedido = pedido.ValorTotalDoPedido;

            _repositorio.UpdateAndSaveChanges(pedidoAlterado);
        }

        public List<Pedido> Listar()
        {
            return _repositorio.List<Pedido>().ToList();
        }

        public void Salvar(Pedido pedido)
        {
            _repositorio.InsertAndSaveChanges(pedido);
        }
    }
}
