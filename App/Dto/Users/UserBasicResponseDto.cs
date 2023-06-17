namespace App.Dto.Users
{
    public class UserBasicResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Phone { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

    }
}
