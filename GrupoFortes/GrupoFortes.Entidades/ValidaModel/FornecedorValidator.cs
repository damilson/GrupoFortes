using GrupoFortes.Entidades.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoFortes.Entidades.ValidaModel
{
    public class FornecedorValidator
    {
        public void Validar(Fornecedor fornecedor)
        {
            if (string.IsNullOrWhiteSpace(fornecedor.NomeContato))
                throw new Exception("O nome do fonecedor não pode ser nulo");

            if (string.IsNullOrWhiteSpace(fornecedor.CNPJ))
                throw new Exception("O CNPJ do fornecedor não pode ser nulo");

            if (string.IsNullOrWhiteSpace(fornecedor.RazaoSocial))
                throw new Exception("A razão social do fornecedor não pode ser nulo");

            if (string.IsNullOrWhiteSpace(fornecedor.UF))
                throw new Exception("O UF do fornecedor não pode ser nulo");

            if (string.IsNullOrWhiteSpace(fornecedor.EmailContato))
                throw new Exception("O Email do fornecedor não pode ser nulo");
        }
    }
}
