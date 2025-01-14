using eMoviesTickets.Data.BaseRepository;
using eMoviesTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMoviesTickets.Models
{
    public class NewMovieVM
    {
        public int Id  { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Movie Picture URL")]
        [Required(ErrorMessage = "Movie Picture URL is required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Price BWP")]
        [Required(ErrorMessage = "Price Required")]
        public double Price { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is Required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is Required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Movie Category")]
        [Required(ErrorMessage = "Movie Category is Required")]
        public MovieCategory MovieCategory { get; set; }


        //Relationships
        [Display(Name = "Select the cinema")]
        [Required(ErrorMessage = "Cinema is required")]
        public int CinemaId { get; set; }

        [Display(Name = "Select producer")]
        [Required(ErrorMessage = "Producer is Required")]
        public int ProducerId { get; set; }

        [Display(Name = "Select Actor(s)")]
        [Required(ErrorMessage = "Actors required")]
        public List<int> ActorIds { get; set; }


    }
}
