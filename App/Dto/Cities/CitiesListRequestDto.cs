namespace App.Dto.Cities
{
    public class CitiesListRequestDto
    {
        public string UF { get; set; }
        public int QtyByPage { get; set; }
        public int Page { get; set; }
        public int Skip { get; set; }
        public string? Filter { get; set; }
    }

}
