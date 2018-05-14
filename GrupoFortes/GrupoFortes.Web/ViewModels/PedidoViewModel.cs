using GrupoFortes.Entidades.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GrupoFortes.Web.ViewModels
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }

        [Required]
        [Display(Name =@"Fornecedor")]
        public int FornecedorId { get; set; }

        [Display(Name =@"Codigo")]
        public int CodigoDoPedido { get; set; }

        [Display(Name =@"Codigo do Produto")]
        public int CodigoDoProduto { get; set; }

        [Display(Name =@"Descrição do Produto")]
        public string DescricaoDoProduto { get; set; }

        [Display(Name =@"Quantidade")]
        public int QuantidadeProduto { get; set; }

        [Display(Name =@"Data do pedido")]
        public string DataDoPedido { get; set; }

        public List<Item> Itens { get; set; }

        [Display(Name =@"Quantidade de produtos")]
        public int QuantidadeDeProdutos { get; set; }

        [Display(Name =@"Valor total")]
        public double ValorTotalDoPedido { get; set; }

        public int QuantidadeItens { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public List<Pedido> ListaPedidos { get; set; }

        public List<Item> ListaItens { get; set; }

        public IEnumerable<SelectListItem> ListaFornecedores { get; set; }
    }
}