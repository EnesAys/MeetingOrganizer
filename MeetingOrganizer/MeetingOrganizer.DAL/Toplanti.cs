using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DAL
{
    public class Toplanti
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen Toplantı Konusunu Belirtiniz")]
        [Display(Name = "Toplantı Konusu")]
        public string Konu { get; set; }

        [Required(ErrorMessage = "Toplantı Tarihini Belirtiniz")]
        [Display(Name = "Toplantı Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime T_Tarih { get; set; }

        [Display(Name = "Başlangıç Saati")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Required(ErrorMessage = "Toplantının Başlangıç Saatini Belirtiniz")]
        public DateTime BaslangicSaat { get; set; }
        [Required(ErrorMessage = "Toplantının Bitiş Saatini Belirtiniz")]
        [Display(Name = "Bitiş Saati")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime BitisSaat { get; set; }

        //Mapping
        public ICollection<Katilimci> Katilimcilar { get; set; }
    }
}
