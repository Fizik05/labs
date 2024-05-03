using System.ComponentModel.DataAnnotations.Schema;

namespace Third_laba.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public Owner? Owner { get; set; }
    }
}
