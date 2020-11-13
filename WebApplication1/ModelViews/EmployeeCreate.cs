using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ModelViews
{
    public class EmployeeCreate
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="FullName is required")]
        public string FullName { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Day of Birth is required")]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
    }
}
