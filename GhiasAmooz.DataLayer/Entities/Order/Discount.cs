﻿using System;
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

        [Required]
        [MaxLength(150)]
        public string DiscountCode { get; set; }

        [Required]
        public int DiscountPercent { get; set; }

        public int? UsableCount { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
