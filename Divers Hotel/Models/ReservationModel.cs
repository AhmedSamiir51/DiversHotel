using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Models
{
    public class ReservationModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "User Name Is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Not Valid Email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Country Is Required")]
        public string Country { get; set; }
        [Required(ErrorMessage = " Room Type  Is Required")]
        public int RoomType { get; set; }


        [Range(0,2,ErrorMessage ="Max Adult is 2 ")]
        public int? Adult { get; set; }
        [Range(0, 2, ErrorMessage = "Max Children is 2 ")]
        
        public int? Children { get; set; }

        [Required(ErrorMessage = "Male  Is Required")]

        public int NameMale { get; set; }

        [Required]
        public DateTime Check_In { get; set; }
        [Required]
        public DateTime Check_Out { get; set; }

    }
}
