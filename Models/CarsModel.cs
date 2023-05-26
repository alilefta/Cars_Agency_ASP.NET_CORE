using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAgency.Models
{
    [Table("Main_Table")]

    public class CarsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("الرقم التسلسلي")]

        public int CarId { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = " الاسم يجب ان يكون مابين 4 و 20 حرفاً")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "يجب ان يحتوي الاسم على احرف فقط")]
        // [RegularExpression(@"^[\u0621-\u064A ]+$")] للحروف العربية فقط
        [DisplayName("اسم الوكيل")]
        public String ClientName { get; set; }


        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "الاسم يجب ان يكون مابين 4 احرف")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "يجب ان يحتوي الاسم على احرف فقط")]
        // [RegularExpression(@"^[\u0621-\u064A ]+$")] للحروف العربية فقط
        [DisplayName("الشركة المصنعة")]
        public String Make { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [RegularExpression(@"^(\+\d{1,3}[- ]?)\d{11}$", ErrorMessage = "رقم الموبايل غير صحيح")]
        // [RegularExpression(@"^[\u0621-\u064A ]+$")] للحروف العربية فقط
        [DisplayName("رقم موبايل الوكيل")]
        public string ClientPhone { get; set; }

        [Required]
        [DisplayName("طراز السيارة")]

        public String Model { get; set; }
        [Required]
        [DisplayName("سنة الصنع")]

        public String Year { get; set; }
        [Required]
        [DisplayName("الرقم التعريفي للسيارة")]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        [StringLength(17, ErrorMessage = "الرقم التعريفي يتكون من 17 حرف ورقم")]

        public String Vin { get; set; }

        [Required]
        [DisplayName("بلد المنشأ")]
        [ForeignKey("ManufacturingCountry")]
        public int ManufacturingCountryId { get; set; }
        public virtual ManufacuringCountry ManufacturingCountry { get; set; }


        // ----------------------
        // New Inputs


        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("الجنس")]
        [ForeignKey("Gender")]
        public int CarsAgentGenderID { get; set; }
        public virtual Gender Gender { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "الاسم يجب ان يكون مابين 4 احرف")]
        [DisplayName("Graduate")]
        public String Graduate { get; set; }


        // ---------------------


    }
}
