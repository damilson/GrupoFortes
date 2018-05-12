using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util.Enumeradores;

namespace GrupoFortes.Servico.DTO
{
    public class CordenadorDTO
    {
        public int CordenadorId { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public CategorioaDeEnsino CategorioDeEnsino { get; set; }
        public IList<ProfessorDTO> Professores { get; set; }
    }
}