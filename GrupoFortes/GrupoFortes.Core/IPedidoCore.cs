using GrupoFortes.Entidades.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoFortes.Core
{
    public interface IPedidoCore
    {
        List<Pedido> Listar(int idFornecedor = 0);

        Pedido Buscar(int id);

        void Editar(Pedido pedido);

        void Salvar(Pedido pedido);

        void Deletar(int id);
    }
}
