using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DAL
{
   public class Katilimci
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Ad { get; set; }
        [MaxLength(50, ErrorMessage = "50 karakterden uzun olamaz")]
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Soyad { get; set; }
      
       
        public System.Nullable<int> ToplantiID { get; set; }

        //Mapping   
        [ForeignKey("ToplantiID")]
        public virtual Toplanti Toplanti { get; set; }
    }
}
