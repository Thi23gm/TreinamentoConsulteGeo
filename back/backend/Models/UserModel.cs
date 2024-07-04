using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool isActive { get; set; }
        public int age { get; set; }
        public string? eyeColor { get; set; }
        public string? name { get; set; }
    }
}