using GrupoFortes.Entidades.Model;
using System;

namespace GrupoFortes.Entidades.ValidaModel
{
    public class ProdutoValidate
    {
        public void Validar(Produto produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Descricao))
                throw new Exception("A descrição do produo não pode ser vazia");

            if (produto.ValordoProduto <= 0)
                throw new Exception("O valor do produto não pode sr 0");

        }
    }
}