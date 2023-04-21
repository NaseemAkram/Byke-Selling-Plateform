using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BykeSellingOnlinePlatefrom.Models
{
    public class Application_User : IdentityUser
    {
        [DisplayName("Office Phone Number")]
        public string PhoneNumber2 { get; set; }
        [NotMapped]

        public bool IsAdmin { get; set; }
    }
}
