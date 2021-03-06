﻿using GrupoFortes.Servico.DTO;
using System.Collections.Generic;

namespace GrupoFortes.Servico.Interface
{
    public interface IUsuarioServico
    {
        List<UsuarioDTO> Get();

        UsuarioDTO Get(int id);

        UsuarioDTO Get(string id);

        void Post(UsuarioDTO usuario);

        void Put(UsuarioDTO usuario);

        void Delete(int id);
    }
}
