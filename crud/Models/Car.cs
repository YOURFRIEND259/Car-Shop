using MessagePack;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud.Models
{
    public class Car 
    {
        [Key]
        public int Id { get; set; } 
        [Required(ErrorMessage = "Mark is required!")]
        public string ?Mark { get; set; }
        [Required(ErrorMessage = "Model is required!")]
        public string ?Model { get; set; } 
        [Required(ErrorMessage = "Color is required!")]
        public string ?Color { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "Price is required!")]
        public decimal Price { get; set; }
        public byte[]? Picture { get; set; }

    }
}
