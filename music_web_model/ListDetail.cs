using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace music_app_model
{
    public class ListDetail
    {
        [Key]
        public int IdListDetail { get; set; }
        [ForeignKey("Song")]
        public int IdSong { get; set; }
        [ForeignKey("PlayList")]
        public int IdList { get; set; }
        public Song? Song { get; set; }
        public PlayList? PlayList { get; set; }
    }
}
