using GhiasAmooz.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhiasAmooz.DataLayer.Entities.Order
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }

        
        [Display(Name = "کد تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string DiscountCode { get; set; }

        [Display(Name = "درصد تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
       
        public int DiscountPercent { get; set; }

        public int? UsableCount { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        #region Relations
        public List<UserDiscoundCode> UserDiscoundCodes { get; set; }
        #endregion
    }
}
