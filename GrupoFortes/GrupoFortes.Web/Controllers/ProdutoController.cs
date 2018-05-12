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
            var produto = _produto.Buscar(id);

            var PVM = new ProdutoViewModel
            {
                CodigoProduto = produto.CodigoProduto,
                DataDoCadastro = produto.DataDoCadastro,
                Descricao = produto.Descricao,
                ValordoProduto = produto.ValordoProduto,
                ProdudoId = produto.ProdutoId
            };

            return View(PVM);
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
                CodigoProduto = model.CodigoProduto,
                Descricao = model.Descricao,
                ValordoProduto = model.ValordoProduto,
                DataDoCadastro = DateTime.Now
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
        public ActionResult EditView(int id)
        {
            var produto = _produto.Buscar(id);

            var PVM = new ProdutoViewModel
            {
                CodigoProduto = produto.CodigoProduto,
                DataDoCadastro = produto.DataDoCadastro,
                Descricao = produto.Descricao,
                ValordoProduto = produto.ValordoProduto,
                ProdudoId = produto.ProdutoId
            };
            return View("Edit", PVM);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public JsonResult Edit(ProdutoViewModel model)
        {
            try
            {
                var produto = new Produto
                {
                    ProdutoId = model.ProdudoId,
                    CodigoProduto = model.CodigoProduto,
                    Descricao = model.Descricao,
                    ValordoProduto = model.ValordoProduto,
                    DataDoCadastro = DateTime.Now
                };

                _produto.Editar(produto);
                return Alerta.CriaMensagemSucesso("Produto alterado com sucesso");
            }
            catch (Exception ex)
            {
                return Alerta.CriaMensagemErro("Não foi possivel alterar o produto. Erro: " + ex.Message);
            }
        }

        // GET: Produto/Delete/5
        public JsonResult Delete(int id)
        {
            try
            {
                _produto.Deletar(id);

                return Alerta.CriaMensagemSucesso("Produto deletado com sucesso");
            }catch(Exception ex)
            {
                return Alerta.CriaMensagemErro("Naoo foi possivel deletar o produto. Erro: " + ex.Message);
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
