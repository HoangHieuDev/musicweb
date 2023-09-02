using System.ComponentModel.DataAnnotations;

namespace music_app_model
{
    public class CategorySong
    {
        [Key]
        public int IdCategory { get; set; }
        [Display(Name = "Category name")]
        public string NameCategory { get; set; } = default!;
        public ICollection<Song> Song { get; set; } = default!;

    }
}
