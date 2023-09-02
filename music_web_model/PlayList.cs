using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace music_app_model
{
    public class PlayList
    {
        [Key]
        public int IdList { get; set; }
        public string NameList { set; get; } = default!;
        [ForeignKey("User")]
        public int IdUser { get; set; }
        public User? User { get; set; }
        public ICollection<ListDetail> ListDetail { get; set; } = default!;
    }
}
