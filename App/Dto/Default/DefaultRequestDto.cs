namespace App.Dto.Default {
    public class DefaultRequestDto {
        public int QtyByPage { get; set; }
        public int Page { get; set; }
        public int Skip { get; set; }
        public string? Filter { get; set; }
     
    }
}
