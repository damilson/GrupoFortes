using GrupoFortes.Servico.DTO;
using System.Collections.Generic;

namespace GrupoFortes.Servico.Interface
{
    public interface IProfessorServico
    {
        List<ProfessorDTO> Get();

        ProfessorDTO Get(int Id);

        ProfessorDTO Get(string Id);

        void Post(ProfessorDTO usuario);

        void Put(ProfessorDTO usuario);

        void Delete(int Id);
    }
}
