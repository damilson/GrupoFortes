using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoFortes.Entidades.Model
{
    public class Item
    {
        public virtual int ItemId { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual int Quantidade { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
