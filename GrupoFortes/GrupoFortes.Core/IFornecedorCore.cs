using GrupoFortes.Entidades.Model;
using System.Collections.Generic;

namespace GrupoFortes.Core
{
    public interface IFornecedorCore
    {
        List<Fornecedor> Listar();

        Fornecedor Buscar(int id);

        void Editar(Fornecedor fornecedor);

        void Salvar(Fornecedor fornecedor);

        void Deletar(int id);
    }
}
