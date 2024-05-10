namespace ProjectWithSeedAsync.Application.Dto
{
    public class CityDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Code { get; set; }

        public int StateId { get; set; }

        public StateDto? State { get; set; }
    }
}
