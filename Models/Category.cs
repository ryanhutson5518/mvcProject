using System;
using System.Collections.Generic;
using System.ComponentModel;   
using System.ComponentModel.DataAnnotations; // Makes the first col the primary key
using System.Linq;
using System.Threading.Tasks;

namespace mvcProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]   // This method can be used for "asp-for"   ...   this changes the asp-for tag from DisplayOrder to Display Order for the view

        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Display Order for category must be greater than 0")]
        public int DisplayOrder { get; set; }
    }
}
