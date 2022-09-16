using MessagePack;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace crud.Models
{
    public class Car 
    {
        [Key]
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

    }
}
