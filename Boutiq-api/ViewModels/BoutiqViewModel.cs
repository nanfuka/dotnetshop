using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Boutiq_api.ViewModels
{
    public class BoutiqViewModel

    {

        [Required(ErrorMessage = "Please enter the type")]
        [Display(Name = "Type of Item")]
        [StringLength(100)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please Describe the item")]
        [Display(Name = "Description")]
        [StringLength(100)]
        public string Description { get; set; }

        [Display(Name = "Cost")]
        public int Cost { get; set; }


        public string DateOfEntry { get; set; }

        [Required(ErrorMessage = "Please submit the current status of the item")]
        public string status { get; set; }

        [Required(ErrorMessage = "Please submit the item image")]
        public IFormFile itemImage { get; set; }

        [Required(ErrorMessage = "Please Enter teh sale price of this item")]

        public int SalePrice { get; set; }
        public string DateOfSale { get; set; }
    }
}

