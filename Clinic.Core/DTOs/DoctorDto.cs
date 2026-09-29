using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    public class CreateDoctorDto
    {
        [Required(ErrorMessage = "اسم الطبيب مطلوب.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "اسم الطبيب يجب أن يكون بين 3 و 100 حرف.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "التخصص مطلوب.")]
        [StringLength(50, ErrorMessage = "التخصص لا يجب أن يتجاوز 50 حرف.")]
        public string Specialization { get; set; } = string.Empty;

        [Required(ErrorMessage = "رقم الهاتف مطلوب.")]
        [Phone(ErrorMessage = "صيغة رقم الهاتف غير صحيحة.")]
        public string Phone { get; set; } = string.Empty;
    }
}
