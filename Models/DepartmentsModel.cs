using System.ComponentModel.DataAnnotations;

namespace CDRMS_Web_Application.Models
{
    public class DepartmentsModel
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
