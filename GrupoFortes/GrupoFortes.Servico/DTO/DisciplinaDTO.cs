using System.Collections.Generic;

namespace GrupoFortes.Servico.DTO
{
    public class DisciplinaDTO
    {
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        public IList<ProfessorDTO> Professores { get; set; }
        public IList<FrequenciaDTO> Frequencias { get; set; }
        public bool Excluida { get; set; }
    }
}