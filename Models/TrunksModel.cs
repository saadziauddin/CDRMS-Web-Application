using System.ComponentModel.DataAnnotations;

namespace CDRMS_Web_Application.Models
{
    public class TrunksModel
    {
        [Key]
        public int TrunkId { get; set; }

        public int DepartId { get; set; }

        public int TrunkCode { get; set; }
    }
}
