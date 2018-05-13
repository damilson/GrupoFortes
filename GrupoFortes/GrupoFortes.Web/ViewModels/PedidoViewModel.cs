using GrupoFortes.Entidades.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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

        public List<Produto> Produto { get; set; }

        [Display(Name =@"Quantidade de produtos")]
        public int QuantidadeDeProdutos { get; set; }

        [Display(Name =@"Valor total")]
        public double ValorTotalDoPedido { get; set; }

        public List<Pedido> ListaPedidos { get; set; }

        public IEnumerable<SelectListItem> ListaFornecedores { get; set; }
    }
}