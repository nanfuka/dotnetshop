using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Boutiq_api.Models
{
    public class Boutiq
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the type")]
        [Display(Name = "Type of Item")]
        [StringLength(100)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please Describe the item")]
        [Display(Name = "Description")]
        [StringLength(100)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please submit the price at which you purchased this item")]
        [Display(Name = "Cost")]
        public int Cost { get; set; }
        [Required(ErrorMessage = "Please enter teh date when this item was added to the boutiq")]
        public string DateOfEntry { get; set; }

        [Required(ErrorMessage = "Please submit the current status of the item")]
        public string status { get; set; }

        [Required(ErrorMessage = "Please submit the item image")]
        public string itemImage { get; set; }
        [Required(ErrorMessage = "Please Enter teh sale price of this item")]

        public int SalePrice { get; set; }
        public DateTime DateOfSale { get; set; }

        public int BoutiqWorth { get; set; }

        public int Profit {

            get
            {
                return SalePrice - Cost;
            }

        }




    }
}
