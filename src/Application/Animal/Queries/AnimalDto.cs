using AutoMapper;
using ZooApp.Application.Common.Mappings;
using ZooApp.Domain.Entities;

namespace ZooApp.Application.Animal.Queries
{
    public class AnimalDto : IMapFrom<AnimalEntity>
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Raza { get; set; }
        public virtual int Edad { get; set; }
        public virtual string Genero { get; set; }
        public virtual string Comida { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AnimalEntity, AnimalDto>();
        }
    }
}
