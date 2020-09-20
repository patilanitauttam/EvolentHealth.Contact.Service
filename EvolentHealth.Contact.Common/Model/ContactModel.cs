using System.ComponentModel.DataAnnotations;

namespace EvolentHealth.Contact.Common.Model
{
    public partial class ContactModel
    {
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
    }
}
