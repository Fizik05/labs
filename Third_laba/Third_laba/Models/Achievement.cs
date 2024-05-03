using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Third_laba.Models
{
    public class Achievement
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
