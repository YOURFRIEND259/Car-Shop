using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace crud.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Mark is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Money is required!")]
        public decimal Money { get; set; }


    }
}
