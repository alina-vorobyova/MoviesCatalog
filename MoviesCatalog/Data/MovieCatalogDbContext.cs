using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MoviesCatalog.Models;

namespace MoviesCatalog.Data
{
    public class MovieCatalogDbContext : IdentityDbContext
    {
        public MovieCatalogDbContext(DbContextOptions<MovieCatalogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public void SeedDatabase()
        {
            if (Movies.Any())
                return;

            var firstUser = Users.FirstOrDefault();

            Movies.Add(new Movie()
            {
                Title = "The Hobbit: An Unexpected Journey",
                Description = "A reluctant Hobbit, Bilbo Baggins, sets out to the Lonely Mountain with a spirited group of dwarves to reclaim their mountain home, and the gold within it from the dragon Smaug.",
                Poster = "/uploads/46140578-5eb0-487e-8659-0502c659c297.jpg",
                Year = 2012,
                IdentityUser = firstUser
            });

            Movies.Add(new Movie()
            {
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron..",
                Poster = "/uploads/be369eaf-e60b-4725-bf83-9c8a871f1932.jpg",
                Year = 2001,
                IdentityUser = firstUser
            });

            Movies.Add(new Movie()
            {
                Title = "Interstellar",
                Description = "In the future, where Earth is becoming uninhabitable, farmer and ex-NASA pilot Cooper is asked to pilot a spacecraft along with a team of researchers to find a new planet for humans.",
                Poster = "/uploads/deae25d2-b768-4880-a258-8d6094e98ae2.jpg",
                Year = 2014,
                IdentityUser = firstUser
            });

            Movies.Add(new Movie()
            {
                Title = "The Witcher",
                Description = "The witcher Geralt, a mutated monster hunter, struggles to find his place in a world in which people often prove more wicked than beasts.",
                Poster = "/uploads/be5bca88-8de8-4bbe-98e8-a6bf973edda1.jpg",
                Year = 2019,
                IdentityUser = firstUser
            });

            Movies.Add(new Movie()
            {
                Title = "The Big Bang Theory",
                Description = "A woman who moves into an apartment across the hall from two brilliant but socially awkward physicists shows them how little they know about life outside of the laboratory.",
                Poster = "/uploads/5df671f5-a9ce-47d0-8128-438c51b29bf0.jpg",
                Year = 2007,
                IdentityUser = firstUser
            });

            Movies.Add(new Movie()
            {
                Title = "Stranger Things",
                Description = "This thrilling Netflix original drama stars Golden Globe-winning actress Winona Ryder as Joyce Byers, who lives in a small Indiana town in 1983 -- inspired by a time when tales of science fiction captivated audiences. When Joyce's 12-year-old son, Will, goes missing, she launches a terrifying investigation into his disappearance with local authorities. As they search for answers, they unravel a series of extraordinary mysteries involving secret government experiments, unnerving supernatural forces, and a very unusual little girl.",
                Poster = "/uploads/d0d865f6-1b5d-4d68-a01b-5c4ff6c39651.jpg",
                Year = 2016,
                IdentityUser = firstUser
            });

            Movies.Add(new Movie()
            {
                Title = "Daredevil",
                Description = "Matt Murdock manages to overcome the challenges that he faces due to him being blind since childhood and fights criminals as a lawyer and Daredevil.",
                Poster = "/uploads/4d5323c7-d331-4b1e-a6d7-1e007a551c7d.jpg",
                Year = 2015,
                IdentityUser = firstUser
            });

            Movies.Add(new Movie()
            {
                Title = "Inception",
                Description = "Cobb steals information from his targets by entering their dreams. Saito offers to wipe clean Cobb's criminal history as payment for performing an inception on his sick competitor's son.",
                Poster = "/uploads/c57a958d-826b-4029-a819-a3ff84655e4b.jpg",
                Year = 2010,
                IdentityUser = firstUser
            });

            Movies.Add(new Movie()
            {
                Title = "2001: A Space Odyssey",
                Description = "The Discovery One and its revolutionary super computer seek a mysterious monolith that first appeared at the dawn of man.",
                Poster = "/uploads/951798ef-8d41-43a3-ab03-eb08e4cc1c6c.jpg",
                Year = 1968,
                IdentityUser = firstUser
            });

            Movies.Add(new Movie()
            {
                Title = "Insidious ",
                Description = "A family looks to prevent evil spirits from trapping their comatose child in a realm called The Further.",
                Poster = "/uploads/5c925419-ee55-4d6d-a581-12ca6c884e31.jpg",
                Year = 2010,
                IdentityUser = firstUser
            });

            Movies.Add(new Movie()
            {
                Title = "The Hobbit: The Desolation of Smaug",
                Description = "Bilbo Baggins, a hobbit, and his companions face great dangers on their journey to Laketown. Soon, they reach the Lonely Mountain, where Bilbo comes face-to-face with the fearsome dragon Smaug.",
                Poster = "/uploads/7827040d-b478-49d7-8cc0-606b0eeff22a.jpg",
                Year = 2013,
                IdentityUser = firstUser
            });


            SaveChanges();
        }
    }
}
