using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.Stock
{
    public class CreateStockRequestDTO
    {
        [Required(ErrorMessage = "Symbol is required!")]
        public string Symbol { get; set; } = string.Empty;
        [Required(ErrorMessage = "Company Name is required!")]
        public string CompanyName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Purchase is required!")]
        public decimal Purchase { get; set; }
        [Required(ErrorMessage = "Last Div is required!")]
        public decimal LastDiv { get; set; }
        [Required(ErrorMessage = "Industry is required!")]
        public string Industry { get; set; } = string.Empty;
        [Required(ErrorMessage = "Market Cap is required!")]
        public long MarketCap { get; set; }
    }
}