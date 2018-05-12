using GrupoFortes.Core;
using GrupoFortes.Entidades.Model;
using GrupoFortes.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util.Alerta;

namespace GrupoFortes.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoCore _produto;

        public ProdutoController(IProdutoCore produto)
        {
            _produto = produto;
        }

        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Produto/Create
        public ActionResult CreateView()
        {
            return View("Create");
        }

        // POST: Produto/Create
        public JsonResult Create(ProdutoViewModel model)
        {
            var produto = new Produto
            {
                Descricao = model.Descricao,
                ValordoProduto = model.ValordoProduto,
                DataDoCadastro = DateTime.Today
            };
            try
            {
                _produto.Salvar(produto);
                return Alerta.CriaMensagemSucesso("Produto cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return Alerta.CriaMensagemErro("Falha ao cadastrar produto. Erro: " + ex.Message);
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Tabela()
        {
            var PVM = new ProdutoViewModel();

            PVM.ListaProdutos = _produto.Listar();

            return View("_Tabela", PVM);
        }
    }
}
