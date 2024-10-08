using System.ComponentModel.DataAnnotations;

namespace WooxTravelProject.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [StringLength(100)]
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}