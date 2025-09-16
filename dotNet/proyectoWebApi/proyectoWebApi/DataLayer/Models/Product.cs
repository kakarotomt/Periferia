using System.ComponentModel.DataAnnotations;

namespace proyectoWebApi.DataLayer.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string InternalReference { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Estate { get; set; }
        public string MeassureUnit { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
