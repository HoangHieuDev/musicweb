using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace music_app_model
{
    public class Singer
    {
        [Key]
        public int IDSinger { get; set; }

        [Required]
        [Display(Name = "Singer name")]
        public string? NameSinger { get; set; }
        [Required]
        [Display(Name = "Year of birth")]
        public string YearOfBirth { get; set; } = default!;
        public string? Gender { set; get; }
        [Required]
        public string Nationality { set; get; } = default!;
        [Required]
        [Display]
        public string Avatar { get; set; } = default!;
        [Required]
        [Display]
        public string Biography { set; get; } = default!;
        public string? AddDate { set; get; }
        public string? UpdDate { set; get; }
        public ICollection<Song>? Song { get; set; } = default!;

    }
}
