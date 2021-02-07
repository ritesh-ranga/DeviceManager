using System;
using System.ComponentModel.DataAnnotations;

namespace DeviceManager.Shared.Models
{
    public class Device
    {
        [Display(Name = "ID")]
        // [HiddenInput(DisplayValue = false)]
        public int id { get; set; }

        [Display(Name = "Location")]
        public string location { get; set; }

        [Display(Name = "Type")]
        public string type { get; set; }

        [Display(Name = "Health")]
        [Required(ErrorMessage = "Please enter health")]
        public string device_health { get; set; }

        [Display(Name = "Last Used")]
        [DataType(DataType.Date)]
        public DateTime last_used { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public double price { get; set; }

        [Display(Name = "Color")]
        public string color { get; set; }
    }
}
