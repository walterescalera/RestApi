using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Domain.Entities
{
    public class Person
    {
        public int PersonId { get; set; }

        public string LastName{ get; set; }

        public string Name { get; set; }

        public long Cuil { get; set; }

        public Gender Gender { get; set; }
    }
}
