using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : BaseEntityWithId
    {
        public User()
        {
            this.PushNotificationKeys = new HashSet<PushNotificationKey>();
            this.CodeValidations = new HashSet<CodeValidation>();
        }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string? SurName { get; set; }
        [MaxLength(20)]
        public string? DocNumber { get; set; }
        public DateTime? Birthday { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(500)]
        public string Password { get; set; }
        public bool? EmailValidated { get; set; }
        public virtual ICollection<PushNotificationKey> PushNotificationKeys { get; set; }

        [ForeignKey("UserTypeId")]
        [Required]
        public UserType UserType { get; set; }
        public long UserTypeId { get; set; }
        public string? PhotoUrl { get; set; }
        public bool? TwoFactory { get; set; }
        public string? TwoFactorySecret { get; set; }
        public string? PinCode { get; set; }
        public virtual ICollection<CodeValidation> CodeValidations { get; set; }
    }
}
