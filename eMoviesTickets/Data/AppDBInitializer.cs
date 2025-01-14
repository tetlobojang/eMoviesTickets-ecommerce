using eMoviesTickets.Data.Enums;
using eMoviesTickets.Models;

namespace eMoviesTickets.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder){
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();


                //Add Cinemas
                if (!context.Cinemas.Any()){
                    context.Cinemas.AddRange(new List<Cinema>() {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "../Data/Pictures/Cinema/Cinema 1.jpg",
                            Description = "This is the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "../Data/Pictures/Cinema/Cinema 2.jpg",
                            Description = "This is the second cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "../Data/Pictures/Cinema/Cinema 3.jpg",
                            Description = "This is the third cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "../Data/Pictures/Cinema/Cinema 4.jpg",
                            Description = "This is the fourth cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "../Data/Pictures/Cinema/Cinema 5.jpg",
                            Description = "This is the first cinema"
                        }
                    });
                    context.SaveChanges();
                }
                //Add Actors
                if (!context.Actors.Any()){
                    context.Actors.AddRange(new List<Actor>()
                    {
                         new Actor()
                        {
                            FullName = "Actor 1",
                            ProfilePictureUrl = "../Data/Pictures/Actor/Actor 1.jpg",
                            Bio = "This is the first producer"
                        },
                          new Actor()
                        {
                            FullName = "Actor 2",
                            ProfilePictureUrl = "../Data/Pictures/Actor/Actor 2.jpg",
                            Bio = "This is actor 2"
                        },
                           new Actor()
                        {
                            FullName = "Actor 3",
                            ProfilePictureUrl = "../Data/Pictures/Actor/Actor 3.jpg",
                            Bio = "This is actor 3"
                        },
                            new Actor()
                        {
                            FullName = "Actor 4",
                            ProfilePictureUrl = "../Data/Pictures/Actor/Actor 4.jpg",
                            Bio = "This is actor 4"
                        },
                             new Actor()
                        {
                            FullName = "Actor 5",
                            ProfilePictureUrl = "http://dotnethow.net/images/actors/Actor 1.jpg",
                            Bio = "This is actor 5"
                        },
                    });
                    context.SaveChanges();
                }
                //Add Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>(){
                         new Producer()
                        {
                            FullName = "Producer 1",
                            ProfilePictureUrl = "../Data/Pictures/Producer/Producer 1.jpg",
                            Bio = "This is the first producer"
                        },
                          new Producer()
                        {
                            FullName = "Producer 2",
                            ProfilePictureUrl = "../Data/Pictures/Producer/Producer 2.jpg",
                            Bio = "This is the second producer"
                        },
                           new Producer()
                        {
                            FullName = "Producer 3",
                            ProfilePictureUrl = "../Data/Pictures/Producer/Producer 3.jpg",
                            Bio = "This is the third producer"
                        },
                            new Producer()
                        {
                            FullName = "Producer 4",
                            ProfilePictureUrl = "../Data/Pictures/Producer/Producer 4.jpg",
                            Bio = "This is the fourth producer"
                        },
                             new Producer()
                        {
                            FullName = "Producer 5",
                            ProfilePictureUrl = "../Data/Pictures/Producer/Producer 5.jpg",
                            Bio = "This is the fifth producer"
                        },


                    });
                    context.SaveChanges();
                }
                //Add Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                         new Movie()
                        {
                            Name = "Expandables 1",
                            Description = "Guns blazing",
                            ImageUrl = "../Data/Pictures/Movie/Movie 1.jpg",
                            Price = 46.00,
                            StartDate = DateTime.Now.AddDays(2),
                            EndDate = DateTime.Now.AddDays(6),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                          new Movie()
                        {
                            Name = "Expandables 2",
                            Description = "Guns blazing",
                            ImageUrl = "../Data/Pictures/Movie/Movie 2.jpg",
                            Price = 46.00,
                            StartDate = DateTime.Now.AddDays(2),
                            EndDate = DateTime.Now.AddDays(6),
                            CinemaId = 2,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Action
                        },
                           new Movie()
                        {
                            Name = "The god must be crazy",
                            Description = "Easy going/ chilled vibes",
                            ImageUrl = "../Data/Pictures/Movie/Movie 3.jpg",
                            Price = 56.00,
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(9),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Comedy
                        },
                            new Movie()
                        {
                            Name = "Movie 4",
                            Description = "This is movie 4",
                            ImageUrl = "../Data/Pictures/Movie/Movie 4.jpg",
                            Price = 100.00,
                            StartDate = DateTime.Now.AddDays(-12),
                            EndDate = DateTime.Now.AddDays(-6),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Documentary
                        },
                             new Movie()
                        {
                            Name = "Zulu on my stoep 1",
                            Description = "Comedy and stuff",
                            ImageUrl = "../Data/Pictures/Movie/Movie 5.jpg",
                            Price = 41.00,
                            StartDate = DateTime.Now.AddDays(2),
                            EndDate = DateTime.Now.AddDays(6),
                            CinemaId = 5,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Action
                        },
                              new Movie()
                        {
                            Name = "Expandables 3",
                            Description = "Guns and more guns",
                            ImageUrl = "../Data/Pictures/Movie/Movie 6.jpg",
                            Price = 46.00,
                            StartDate = DateTime.Now.AddDays(4),
                            EndDate = DateTime.Now.AddDays(9),
                            CinemaId = 3,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Action
                        },
                               new Movie()
                        {
                            Name = "New Movie",
                            Description = "Life of Pi",
                            ImageUrl = "../Data/Pictures/Movie/Movie 7.jpg",
                            Price = 100.00,
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 5,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Drama
                        },
                               new Movie()
                        {
                            Name = "New Movie 2",
                            Description = "Life of Pi",
                            ImageUrl = "../Data/Pictures/Movie/Movie 8.jpg",
                            Price = 100.00,
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Drama
                        },

                    });
                    context.SaveChanges();
                }

                //Add Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actors_Movies>()
                    {
                        new Actors_Movies(){ 
                         ActorId = 1,
                         MovieId = 2,
                        },
                        new Actors_Movies(){
                         ActorId = 2,
                         MovieId = 1,
                        },
                        new Actors_Movies(){
                         ActorId = 3,
                         MovieId = 4,
                        },
                        new Actors_Movies(){
                         ActorId = 4,
                         MovieId = 3,
                        },
                        new Actors_Movies(){
                         ActorId = 5,
                         MovieId = 5,
                        },
                        new Actors_Movies(){
                         ActorId = 1,
                         MovieId = 6,
                        },
                        new Actors_Movies(){
                         ActorId = 5,
                         MovieId = 7,
                        },
                        new Actors_Movies(){
                         ActorId = 3,
                         MovieId = 6,
                        }

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
