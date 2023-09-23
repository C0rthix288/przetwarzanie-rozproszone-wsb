using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class NumberModel
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }
    }
}
