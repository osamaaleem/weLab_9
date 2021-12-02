using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using weLab_9.CustomValidation;
using System.Web.Mvc;

namespace weLab_9.Models
{
    public class Marker
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Type  { get; set; }
        [Required]
        [Range(10,100,ErrorMessage = "Price must be 10-100")]
        public int Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [CustomHireDate(ErrorMessage = "Date must be less then today's date")]
        public DateTime PrdDate { get; set; }
        public string PrdDateShort { get; set; }
        public List<SelectListItem> GetColorList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "Red", Value = "Red" });
            list.Add(new SelectListItem { Text = "Black", Value = "Balck" });
            list.Add(new SelectListItem { Text = "Blue", Value = "Blue" });
            list.Add(new SelectListItem { Text = "Green", Value = "Green" });
            return list;
        }
    }
}