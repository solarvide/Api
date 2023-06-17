using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using App.Dto.Company;
using App.Dto.Users;
using Newtonsoft.Json;

namespace App.Dto.Scheduler
{
    public class SchedulerRequestDto
    {

        public DateTime DateInitial { get; set; }
        public DateTime DateEnd { get; set; }
        public string Subject { get; set; }
        public string? Description { get; set; }
        public string? Contact { get; set; }
        public string PhoneContact { get; set; }
        public string? Address { get; set; }
        public string? Number { get; set; }
        public string? Distric { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string? UF { get; set; }

        [JsonIgnore]
        public long? CompanyId { get; set; }
        [JsonIgnore]
        public long? UserId { get; set; }
    }
}
