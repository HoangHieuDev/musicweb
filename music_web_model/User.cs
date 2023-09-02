using System.ComponentModel.DataAnnotations;

namespace music_app_model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Pass { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Avatar { get; set; } = default!;
        public int IsAdmin { get; set; } = default!;
        public ICollection<History> History { get; set; } = default!;
        public ICollection<PlayList> PlayList { get; set; } = default!;

    }
}
