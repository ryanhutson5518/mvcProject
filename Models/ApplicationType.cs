using System;
using System.Collections.Generic;
using System.ComponentModel;   
using System.ComponentModel.DataAnnotations; // Makes the first col the primary key
using System.Linq;
using System.Threading.Tasks;

namespace mvcProject.Models
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
