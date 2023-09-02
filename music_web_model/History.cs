using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace music_app_model
{
    public class History
    {
        [Key]
        public int IdHistory { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }
        [ForeignKey("Song")]
        public int IdSong { get; set; }
        public User? User { get; set; }
        public Song? Song { get; set; }
    }
}
