using System.Collections.Generic;
using System.Linq;
using GrupoFortes.Entidades.Model;
using GrupoFortes.Entidades.ValidaModel;
using GrupoFortes.Repositorio.Repositorio;

namespace GrupoFortes.Core
{
    public class ProdutoCore : IProdutoCore
    {
        private readonly IRepositorio _repositorio;
        private readonly ProdutoValidate produtoValidator;

        public ProdutoCore(IRepositorio repositorio)
        {
            _repositorio = repositorio;
            produtoValidator = new ProdutoValidate();

        }
        public Produto Buscar(int id)
        {
            return _repositorio.Find<Produto>(x => x.ProdutoId == id);
        }

        public void Deletar(int id)
        {
            _repositorio.DeleteAndSaveChanges<Produto>(x => x.ProdutoId == id);
        }

        public void Editar(Produto produto)
        {
            produtoValidator.Validar(produto);

            var produtoAlterado = _repositorio.Find<Produto>(x => x.ProdutoId == produto.ProdutoId);

            produtoAlterado.CodigoProduto = produto.CodigoProduto;
            produtoAlterado.Descricao = produto.Descricao;
            produtoAlterado.ValordoProduto = produto.ValordoProduto;

            _repositorio.UpdateAndSaveChanges(produtoAlterado);
        }

        public List<Produto> Listar()
        {
            return _repositorio.List<Produto>().ToList();
        }

        public void Salvar(Produto produto)
        {
            produtoValidator.Validar(produto);

            _repositorio.InsertAndSaveChanges(produto);
        }
    }
}
