using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agri_Energy_Connect_Application.Models
{
    public class FarmerProduct
    {

        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [ForeignKey("FarmerCategory")]
        public int CategoryID { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        public string ImagePath { get; set; }

        [ForeignKey("AspNetUsers")]
        public string Users { get; set; }

    }
}
