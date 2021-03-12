using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayTransact.Models.ViewModels
{
    public class InvestViewModel
    {
        [Required(ErrorMessage = "*Amount required.")]
        [Display(Name = "Investment amount", Prompt = "Amount to invest")]
        public double InvestedAmount { get; set; }

        [Required(ErrorMessage = "*Payment date required.")]
        [Display(Name = "Payment date", Prompt = "When to pay")]
        public DateTime DateOfPayment { get; set; }

        [Required(ErrorMessage = "*Product required.")]
        [Display(Name = "Product to invest")]
        public Guid ProductId { get; set; }

    }
}
