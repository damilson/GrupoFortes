using GrupoFortes.Repositorio.Data;
using GrupoFortes.Servico.DTO;
using System.Collections.Generic;

namespace GrupoFortes.Servico.Interface
{
    public interface IDisciplinaServico
    {
        IList<DisciplinaDTO> Get();

        DisciplinaDTO Get(int Id);

        void Post(DisciplinaDTO disciplina);

        void Put(DisciplinaDTO disciplina);

        void Delete(int Id);
    }
}
