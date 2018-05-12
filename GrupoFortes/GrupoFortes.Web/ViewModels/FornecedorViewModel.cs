using GrupoFortes.Entidades.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrupoFortes.Web.ViewModels
{
    public class FornecedorViewModel
    {
        public int FornecedorId { get; set; }
        [Required]
        [Display(Name =@"Nome")]
        public string NomeContato { get; set; }
        [Required]
        [Display(Name =@"Email")]
        public string EmailContato { get; set; }
        [Required]
        [Display(Name =@"Razão Social")]
        public string RazaoSocial { get; set; }
        [Required]
        [Display(Name =@"CNPJ")]
        public string CNPJ { get; set; }
        [Required]
        [Display(Name =@"UF")]
        public string UF { get; set; }

        public List<Fornecedor> ListaFornecedores { get; set; }
    }
}