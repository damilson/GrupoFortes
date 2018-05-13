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
    public class PedidoController : Controller
    {
        private readonly IPedidoCore _pedido;
        private readonly IFornecedorCore _fornecedor;

        public PedidoController(IPedidoCore pedido, IFornecedorCore fornecedor)
        {
            _pedido = pedido;
            _fornecedor = fornecedor;
        }

        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pedido/Create
        public ActionResult CreateView()
        {
            var PVM = new PedidoViewModel();

            PVM.ListaFornecedores = _fornecedor.Listar().Select(x => new SelectListItem { Value = x.FornecedorId.ToString(), Text = x.NomeContato });

            return View("Create", PVM);
        }

        // POST: Pedido/Create
        public JsonResult Create(PedidoViewModel model)
        {
            try
            {
                var pedido = new Pedido
                {
                    CodigoDoPedido = model.CodigoDoPedido,
                    DataDoPedido = model.DataDoPedido,
                    Fornecedor = new Fornecedor
                    {
                        FornecedorId = model.FornecedorId
                    },
                    Produto = new List<Produto>(),
                    QuantidadeDeProdutos = model.QuantidadeDeProdutos,
                    ValorTotalDoPedido = model.ValorTotalDoPedido
                };

                _pedido.Salvar(pedido);

                return Alerta.CriaMensagemSucesso("Sucesso ao cadastrar pedido");
            }
            catch(Exception ex)
            {
                return Alerta.CriaMensagemErro("Falha ao cadastrar pedido. Erro: "+ex.Message);
            }
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedido/Edit/5
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

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedido/Delete/5
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
            var PVM = new PedidoViewModel();

            PVM.ListaPedidos = _pedido.Listar();

            return View("_Tabela", PVM);
        }
    }
}
