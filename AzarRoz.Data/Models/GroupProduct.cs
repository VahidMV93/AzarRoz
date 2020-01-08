using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzarRoz.Data.Models
{
    public class GroupProduct
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا نام گروه را وارد نمایید.")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        [StringLength(50, ErrorMessage = "نام گروه باید بیشتر از 6 و کمتر از 50 کاراکتر باشد.", MinimumLength = 6)]
        [Display(Name = "نام گروه")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا واحد گروه را وارد نمایید.")]
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        [StringLength(25, ErrorMessage = "واحد گروه باید بیشتر از 2 و کمتر از 25 کاراکتر باشد.", MinimumLength = 2)]
        [Display(Name = "واحد گروه")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "لطفا قیمت گروه را وارد نمایید.")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ريال}")]
        [Display(Name = "قیمت گروه")]
        public double Price { get; set; }
    }
}
