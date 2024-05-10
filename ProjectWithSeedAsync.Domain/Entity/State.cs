using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWithSeedAsync.Domain.Entity
{
    public class State
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Code { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]

        public Country? Country { get; set; }
    }
}
