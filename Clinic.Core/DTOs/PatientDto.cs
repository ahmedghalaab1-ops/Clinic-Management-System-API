using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
    }

    public class CreatePatientDto
    {
        [Required(ErrorMessage = "اسم المريض مطلوب.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "اسم المريض يجب أن يكون بين 3 و 100 حرف.")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 120, ErrorMessage = "عمر المريض يجب أن يكون بين 1 و 120 سنة.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "رقم الهاتف مطلوب.")]
        [Phone(ErrorMessage = "صيغة رقم الهاتف غير صحيحة.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "معرف الطبيب المعالج مطلوب.")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى اختيار طبيب صحيح.")]
        public int DoctorId { get; set; }
    }
}
