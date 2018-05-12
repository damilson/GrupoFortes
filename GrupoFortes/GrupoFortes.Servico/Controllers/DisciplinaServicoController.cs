using GrupoFortes.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GrupoFortes.Repositorio.Data;
using GrupoFortes.Repositorio.Interface;
using AutoMapper;
using GrupoFortes.Repositorio.Model;
using GrupoFortes.Servico.DTO;

namespace GrupoFortes.Servico.Controllers
{
    public class DisciplinaServicoController : IDisciplinaServico
    {
        private readonly IDisciplinaData _disciplinaData;
        private readonly IMapper _mapper;

        public DisciplinaServicoController(IDisciplinaData disciplinaData, IMapper mapper)
        {
            _disciplinaData = disciplinaData;
            _mapper = mapper;
        }
        
        public IList<DisciplinaDTO> Get()
        {
            var listaDisciplinas = _disciplinaData.DisciplinaLista();

            var listaDisciplinasDTO = _mapper.Map<IList<DisciplinaDTO>>(listaDisciplinas);

            return listaDisciplinasDTO;
        }

        public DisciplinaDTO Get(int Id)
        {
            var disciplina = _disciplinaData.Buscar(Id);

            var DDTO = _mapper.Map<DisciplinaDTO>(disciplina);

            return DDTO;
        }

        public void Post(DisciplinaDTO disciplinaDTO)
        {
            ValidarModel(disciplinaDTO);

            var disciplina = _mapper.Map<Disciplina>(disciplinaDTO);

            _disciplinaData.Salvar(disciplina);
        }

        public void Put(DisciplinaDTO disciplinaDTO)
        {
            ValidarModel(disciplinaDTO);

            var disciplina = _mapper.Map<Disciplina>(disciplinaDTO);

            _disciplinaData.Editar(disciplina);
        }

        public void Delete(int Id)
        {
            _disciplinaData.Deletar(Id);
        }

        private void ValidarModel(DisciplinaDTO disciplina)
        {
            if (string.IsNullOrEmpty(disciplina.Nome))
                throw new Exception("O Nome da disciplina não pode se vazio;");
        }

    }
}
