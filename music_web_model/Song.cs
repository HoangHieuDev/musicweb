using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace music_app_model
{
    public class Song
    {
        [Key]
        public int IdSong { get; set; }
        public string? URL { get; set; }
        [Required]
        [Display(Name = "Name song")]
        public string? NameSong { get; set; }
        [Required]
        public string Lyric { get; set; } = default!;
        [Required]
        [Display]
        public int Listens { get; set; }
        [Required]
        public string? DateUpload { get; set; }

        [Required]
        [Display(Name = "Catogory Song")]
        [ForeignKey("CategorySong")]
        public int IdCategory { get; set; }
        [Required]
        [ForeignKey("Singer")]
        public int IdSinger { get; set; }
        [Required]
        public string? ImageSong { get; set; }
        [Required]
        public int Duration { get; set; } = default!;
        public Singer? Singer { get; set; } = default!;
        public CategorySong? CategorySong { get; set; }
        public ICollection<History>? History { get; set; }
        public ICollection<ListDetail>? ListDetail { get; set; }

    }
}
