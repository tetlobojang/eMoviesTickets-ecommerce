using eMoviesTickets.Data.BaseRepository;
using System.ComponentModel.DataAnnotations;


namespace eMoviesTickets.Models
{
    public class Actor: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Full Name")]
        [Required(ErrorMessage ="Fullname is required")]
        public string FullName { get; set; }

        [Display(Name = "Profile-Picture-URL")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Biography")]
        [Required (ErrorMessage ="Biography is required")]
        public string Bio { get; set; }

        //Relationships
        public List<Actors_Movies> Actors_Movies { get; set; } = [];
    }
}
