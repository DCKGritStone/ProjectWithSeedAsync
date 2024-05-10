using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWithSeedAsync.Domain.Entity
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Code { get; set; }

        public int StateId { get; set; }
        [ForeignKey("StateId")]

        public State? State { get; set; }
    }
}
