using System.Collections.Generic;
using System.Linq;
using GrupoFortes.Entidades.Model;
using GrupoFortes.Entidades.ValidaModel;
using GrupoFortes.Repositorio.Repositorio;

namespace GrupoFortes.Core
{
    public class FornecedorCore : IFornecedorCore
    {
        private readonly IRepositorio _repositorio;
        private readonly FornecedorValidator fornecedorValidator;

        public FornecedorCore(IRepositorio repositorio)
        {
            _repositorio = repositorio;
            fornecedorValidator = new FornecedorValidator();
        }

        public Fornecedor Buscar(int id)
        {
            return _repositorio.Find<Fornecedor>(x => x.FornecedorId == id);
        }

        public void Deletar(int id)
        {
            _repositorio.DeleteAndSaveChanges<Fornecedor>(x => x.FornecedorId == id);
        }

        public void Editar(Fornecedor fornecedor)
        {
            fornecedorValidator.Validar(fornecedor);

            var fornecedorAlterado = _repositorio.Find<Fornecedor>(x => x.FornecedorId == fornecedor.FornecedorId);

            fornecedorAlterado.NomeContato = fornecedor.NomeContato;
            fornecedorAlterado.RazaoSocial = fornecedor.RazaoSocial;
            fornecedorAlterado.EmailContato = fornecedor.EmailContato;
            fornecedorAlterado.CNPJ = fornecedor.CNPJ;
            fornecedorAlterado.UF = fornecedor.UF;

            _repositorio.UpdateAndSaveChanges(fornecedorAlterado);
        }

        public List<Fornecedor> Listar()
        {
            return _repositorio.List<Fornecedor>().ToList();
        }

        public void Salvar(Fornecedor fornecedor)
        {
            fornecedorValidator.Validar(fornecedor);

            _repositorio.InsertAndSaveChanges(fornecedor);
        }
    }
}
