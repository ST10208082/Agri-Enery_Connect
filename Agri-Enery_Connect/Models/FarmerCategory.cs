using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agri_Energy_Connect_Application.Models
{
    public class FarmerCategory
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<FarmerProduct> Products { get; set; }
    }
}
