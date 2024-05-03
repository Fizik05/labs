using System.ComponentModel.DataAnnotations.Schema;

namespace Third_laba.Models
{
    public class AchievementCat
    {
        public int Id { get; set; }
        public int CatId {  get; set; }
        [ForeignKey(nameof(CatId))]
        public Cat? Cat { get; set; }

        public int AchievementId {  get; set; }
        [ForeignKey(nameof(AchievementId))]
        public Achievement? Achievement { get; set; }
    }
}
