namespace GrupoFortes.Entidades.Model
{
    public class Fornecedor
    {
        public virtual int FornecedorId { get; set; }
        public virtual string NomeContato { get; set; }
        public virtual string EmailContato { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string CNPJ { get; set; }
        public virtual string UF { get; set; }
    }
}
