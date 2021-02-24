using ZooApp.Domain.Common;
using System.Collections.Generic;

namespace ZooApp.Domain.Entities
{
    public class AnimalEntity : AuditableEntity, IHasDomainEvent
    {
        public virtual int  Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Raza { get; set; }
        public virtual int Edad { get; set; }
        public virtual string Genero { get; set; }
        public virtual string Comida { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
