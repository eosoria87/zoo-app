using AutoMapper;
using ZooApp.Application.Common.Mappings;
using ZooApp.Domain.Entities;

namespace ZooApp.Application.Animal.Queries
{
    public class AnimalFilterDto : IMapFrom<AnimalEntity>
    {
        public virtual string Nombre { get; set; }
        public virtual string Raza { get; set; }
        public virtual int Edad { get; set; }
        public virtual string Genero { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AnimalEntity, AnimalFilterDto>();
        }
    }
}
