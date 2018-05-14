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
            var PVM = new PedidoViewModel();
            PVM.ListaFornecedores = _fornecedor.Listar().Select(x => new SelectListItem { Value = x.FornecedorId.ToString(), Text = x.NomeContato });
            return View(PVM);
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            var pedido = _pedido.Buscar(id);

            var PVM = new PedidoViewModel
            {
                CodigoDoPedido = pedido.CodigoDoPedido,
                Itens = pedido.Itens,
                QuantidadeItens = pedido.QuantidadeDeProdutos,
                ValorTotalDoPedido = pedido.ValorTotalDoPedido,
                DataDoPedido = pedido.DataDoPedido.ToString("dd/MM/yyyy"),
                Fornecedor = pedido.Fornecedor
            };

            return View(PVM);
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
                var listaItens = new List<Item>();

                foreach (var item in model.Itens)
                {
                    listaItens.Add(new Item
                    {
                        Produto = new Produto
                        {
                            CodigoProduto = item.Produto.CodigoProduto,
                            Descricao = item.Produto.Descricao
                        },
                        Quantidade = item.Quantidade
                    });
                }

                var pedido = new Pedido
                {
                    CodigoDoPedido = model.CodigoDoPedido,
                    DataDoPedido = DateTime.Now.Date,
                    Fornecedor = new Fornecedor
                    {
                        FornecedorId = model.FornecedorId
                    },
                    Itens = listaItens,
                    QuantidadeDeProdutos = model.QuantidadeDeProdutos,
                    ValorTotalDoPedido = model.ValorTotalDoPedido
                };

                _pedido.Salvar(pedido);

                return Alerta.CriaMensagemSucesso("Sucesso ao cadastrar pedido");
            }
            catch (Exception ex)
            {
                return Alerta.CriaMensagemErro("Falha ao cadastrar pedido. Erro: " + ex.Message);
            }
        }

        // GET: Pedido/Edit/5
        public ActionResult EditView(int id)
        {
            var pedido = _pedido.Buscar(id);

            var PVM = new PedidoViewModel
            {
                PedidoId = pedido.PedidoId,
                CodigoDoPedido = pedido.CodigoDoPedido,
                Itens = pedido.Itens,
                QuantidadeItens = pedido.QuantidadeDeProdutos,
                ValorTotalDoPedido = pedido.ValorTotalDoPedido,
                DataDoPedido = pedido.DataDoPedido.ToString("dd/MM/yyyy")
            };

            return View("Edit", PVM);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        public JsonResult Edit(PedidoViewModel model)
        {
            try
            {
                var listaItens = new List<Item>();

                if (model.Itens != null)
                {
                    foreach (var item in model.Itens)
                    {
                        listaItens.Add(new Item
                        {
                            ItemId = item.ItemId,
                            Produto = new Produto
                            {
                                CodigoProduto = item.Produto.CodigoProduto,
                                Descricao = item.Produto.Descricao
                            },
                            Quantidade = item.Quantidade
                        });
                    }
                }

                var pedido = new Pedido
                {
                    PedidoId = model.PedidoId,
                    CodigoDoPedido = model.CodigoDoPedido,
                    DataDoPedido = DateTime.Now.Date,
                    Fornecedor = new Fornecedor
                    {
                        FornecedorId = model.FornecedorId
                    },
                    Itens = listaItens,
                    QuantidadeDeProdutos = model.QuantidadeDeProdutos,
                    ValorTotalDoPedido = model.ValorTotalDoPedido
                };

                _pedido.Editar(pedido);

                return Alerta.CriaMensagemSucesso("Sucesso ao editar pedido");
            }
            catch (Exception ex)
            {
                return Alerta.CriaMensagemErro("Falha ao editar pedido. Erro: " + ex.Message);
            }
        }

        // GET: Pedido/Delete/5
        public JsonResult Delete(int id)
        {
            try
            {
                _pedido.Deletar(id);
                return Alerta.CriaMensagemSucesso("Pedido reovido com sucesso.");

            }
            catch (Exception ex)
            {
                return Alerta.CriaMensagemSucesso("Falha ao remover Pedido. Erro: " + ex.Message);
            }
        }

        public ActionResult Tabela(int idFornecedor = 0 )
        {
            var PVM = new PedidoViewModel();

            PVM.ListaPedidos = _pedido.Listar(idFornecedor);

            return View("_Tabela", PVM);
        }
    }
}
