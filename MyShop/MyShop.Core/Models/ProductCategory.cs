using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Category { get; set; }
    }
}
