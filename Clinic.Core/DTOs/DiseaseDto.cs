using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.DTOs
{
    public class DiseaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class CreateDiseaseDto
    {
        [Required(ErrorMessage = "اسم المرض مطلوب.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "اسم المرض يجب أن يكون بين 2 و 100 حرف.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "وصف المرض لا يجب أن يتجاوز 500 حرف.")]
        public string Description { get; set; } = string.Empty;
    }
}
