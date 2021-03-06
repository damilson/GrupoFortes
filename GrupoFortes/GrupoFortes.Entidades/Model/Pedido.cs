﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoFortes.Entidades.Model
{
    public class Pedido
    {
        public virtual int PedidoId { get; set; }
        public virtual int CodigoDoPedido { get; set; }
        public virtual DateTime DataDoPedido { get; set; }
        public virtual List<Item> Itens { get; set; }
        public virtual int QuantidadeDeProdutos { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual double ValorTotalDoPedido { get; set; }
        public virtual bool deletado { get; set; }
    }
}
