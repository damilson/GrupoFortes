﻿using GrupoFortes.Servico.DTO;
using System.Collections.Generic;

namespace GrupoFortes.Servico.Interface
{
    public interface ITurmaServico
    {
        List<TurmaDTO> Get();

        TurmaDTO Get(int Id);

        void Post(TurmaDTO turmaDTO);

        void Put(TurmaDTO turmaDTO);

        void Delete(int Id);
    }
}
