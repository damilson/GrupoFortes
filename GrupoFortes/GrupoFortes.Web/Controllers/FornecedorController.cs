using GrupoFortes.Core;
using GrupoFortes.Entidades.Model;
using GrupoFortes.Web.ViewModels;
using System;
using System.Web.Mvc;
using Util.Alerta;

namespace GrupoFortes.Web.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorCore _fornecedor;

        public FornecedorController(IFornecedorCore fornecedor)
        {
            _fornecedor = fornecedor;
        }

        // GET: Fornecedor
        public ActionResult Index()
        {
            var FVM = new FornecedorViewModel();
            FVM.ListaFornecedores = _fornecedor.Listar();

            return View(FVM);
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(int id)
        {
            var fornecedor = _fornecedor.Buscar(id);
            var FVM = new FornecedorViewModel
            {
                FornecedorId = fornecedor.FornecedorId,
                NomeContato = fornecedor.NomeContato,
                EmailContato = fornecedor.EmailContato,
                CNPJ = fornecedor.CNPJ,
                RazaoSocial = fornecedor.RazaoSocial,
                UF = fornecedor.UF
            };

            return View(FVM);
        }

        // GET: Fornecedor/Create
        public ActionResult CreateView()
        {
            return View("Create");
        }

        // POST: Fornecedor/Create
        public JsonResult Create(FornecedorViewModel model)
        {
            var fornecedor = new Fornecedor
            {
                NomeContato = model.NomeContato,
                EmailContato = model.EmailContato,
                RazaoSocial = model.RazaoSocial,
                CNPJ = model.CNPJ,
                UF = model.UF
            };

            try
            {
                _fornecedor.Salvar(fornecedor);
                return Alerta.CriaMensagemSucesso("Fornecedor cadastrado com sucesso.");
            }
            catch(Exception ex)
            {
                return Alerta.CriaMensagemErro("Falha ao cadastrar fornecedor. Erro: "+ex.Message);
            }
        }

        // GET: Fornecedor/Edit/5
        public ActionResult EditView(int id)
        {
            var fornecedor = _fornecedor.Buscar(id);
            var FVM = new FornecedorViewModel
            {
                FornecedorId = fornecedor.FornecedorId,
                NomeContato = fornecedor.NomeContato,
                EmailContato = fornecedor.EmailContato,
                CNPJ = fornecedor.CNPJ,
                RazaoSocial = fornecedor.RazaoSocial,
                UF = fornecedor.UF
            };

            return View("Edit",FVM);
        }

        // POST: Fornecedor/Edit/5
        public JsonResult Edit(FornecedorViewModel model)
        {
            var fornecedor = new Fornecedor
            {
                FornecedorId = model.FornecedorId,
                NomeContato = model.NomeContato,
                EmailContato = model.EmailContato,
                RazaoSocial = model.RazaoSocial,
                CNPJ = model.CNPJ,
                UF = model.UF
            };

            try
            {
                _fornecedor.Editar(fornecedor);
                return Alerta.CriaMensagemSucesso("Fornecedor alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return Alerta.CriaMensagemErro("Falha ao alterar fornecedor. Erro: " + ex.Message);
            }
        }

        // POST: Fornecedor/Delete/5
        public JsonResult Delete(int id)
        {
            try
            {
                _fornecedor.Deletar(id);
                return Alerta.CriaMensagemSucesso("Fornecedor removido com sucesso.");
            }
            catch(Exception ex)
            {
                return Alerta.CriaMensagemErro("Falha ao remover fornecedor. Erro: " + ex.Message);
            }
        }

        public ActionResult Tabela()
        {
            var FVM = new FornecedorViewModel();
            FVM.ListaFornecedores = _fornecedor.Listar();

            return View("_Tabela",FVM);
        }
    }
}
