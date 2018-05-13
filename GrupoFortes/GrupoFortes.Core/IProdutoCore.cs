using GrupoFortes.Entidades.Model;
using System.Collections.Generic;

namespace GrupoFortes.Core
{
    public interface IProdutoCore
    {
        List<Produto> Listar();

        Produto Buscar(int id);

        Produto PorCodigo(int id);

        void Editar(Produto produto);

        void Salvar(Produto produto);

        void Deletar(int id);
    }
}
