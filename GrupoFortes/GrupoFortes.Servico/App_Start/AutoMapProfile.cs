using AutoMapper;
using GrupoFortes.Repositorio.Model;
using GrupoFortes.Servico.DTO;

namespace GrupoFortes.Servico
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Logradouro, LogradouroDTO>().ReverseMap();
        }
    }
}