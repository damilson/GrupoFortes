using GrupoFortes.Entidades.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrupoFortes.Web.ViewModels
{
    public class ProdutoViewModel
    {
        public int ProdudoId { get; set; }

        [Display(Name =@"Codigo")]
        public int CodigoProduto { get; set; }
        [Required]
        [Display(Name =@"Descrição")]
        public string Descricao { get; set; }
        [Display(Name =@"Data de Cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/aaaa}", ApplyFormatInEditMode = true)]
        public string DataDoCadastro { get; set; }
        [Required]
        [Display(Name =@"Preço")]
        public decimal ValordoProduto { get; set; }

        public List<Produto> ListaProdutos { get; set; }
    }
}