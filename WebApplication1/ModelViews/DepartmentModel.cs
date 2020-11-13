using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ModelViews
{
    public class DepartmentModel
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage ="Department name is require")]
        public string DepartmentName { get; set; }
        public string Decription { get; set; }
    }
}
