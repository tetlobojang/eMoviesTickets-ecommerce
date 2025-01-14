﻿using eMoviesTickets.Data.BaseRepository;
using System.ComponentModel.DataAnnotations;

namespace eMoviesTickets.Models
{
    public class Producer: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relationships 
        List<Movie> Movies { get; set; }
    }
}
