using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoFortes.Entidades.Model
{
    public class Produto
    {
        public virtual int ProdutoId { get; set; }
        public virtual int CodigoProduto { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime DataDoCadastro { get; set; }
        public virtual decimal ValordoProduto { get; set; }
    }
}
