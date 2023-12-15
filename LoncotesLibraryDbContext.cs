using Microsoft.EntityFrameworkCore;
using LoncotesLibrary.Models;
public class LoncotesLibraryDbContext : DbContext
{

    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<MaterialType> MaterialTypes { get; set; }
    public DbSet<Patron> Patrons { get; set; }

    public LoncotesLibraryDbContext(DbContextOptions<LoncotesLibraryDbContext> context) : base(context)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new Genre {Id = 1, Name = "Fantasy"},
            new Genre {Id = 2, Name = "Science Fiction"},
            new Genre {Id = 3, Name = "Mystery"},
            new Genre {Id = 4, Name = "Romance"},
            new Genre {Id = 5, Name = "Thriller"},
            new Genre {Id = 6, Name = "Historical Fiction"},
            new Genre {Id = 7, Name = "Horror"},
            new Genre {Id = 8, Name = "Biography/Autobiography"}
        });

        modelBuilder.Entity<MaterialType>().HasData(new MaterialType[]
        {
            new MaterialType {Id = 1, Name = "Book", CheckoutDays = 7},
            new MaterialType {Id = 2, Name = "CD", CheckoutDays = 5},
            new MaterialType {Id = 3, Name = "Periodical", CheckoutDays = 2},
            new MaterialType {Id = 4, Name = "DVD", CheckoutDays = 3},
            new MaterialType {Id = 5, Name = "Audiobook", CheckoutDays = 7}
        });

        modelBuilder.Entity<Patron>().HasData(new Patron[]
        {
            new Patron {Id = 1, FirstName = "Alice", LastName = "Smith", Address = "456 Library St, Booktown, USA 12345", Email = "alice.smith@email.com", IsActive = true},
            new Patron {Id = 2, FirstName = "Michael", LastName = "Johnson", Address = "789 Reading Ave, Litville, USA 67890", Email = "michael.johnson@email.com", IsActive = true},
            new Patron {Id = 3, FirstName = "Emily", LastName = "Brown", Address = "101 Novel Rd, Storyville, USA 23456", Email = "emily.brown@email.com", IsActive = true},
            new Patron {Id = 4, FirstName = "David", LastName = "Wilson", Address = "202 Fable Dr, Narrativetown, USA 34567", Email = "david.wilson@email.com", IsActive = false},
            new Patron {Id = 5, FirstName = "Sara", LastName = "Miller", Address = "303 Tale Ct, Fictioncity, USA 45678", Email = "sara.miller@email.com", IsActive = true},
            new Patron {Id = 6, FirstName = "James", LastName = "Davis", Address = "404 Legend Ln, Mythosburg, USA 56789", Email = "james.davis@email.com", IsActive = false},
            new Patron {Id = 7, FirstName = "Angela", LastName = "Garcia", Address = "505 Epic St, Fabulaville, USA 67890", Email = "angela.garcia@email.com", IsActive = true},
            new Patron {Id = 8, FirstName = "Robert", LastName = "Martinez", Address = "606 Chronicle Ave, Allegorytown, USA 78901", Email = "robert.martinez@email.com", IsActive = false},
            new Patron {Id = 9, FirstName = "Lisa", LastName = "Hernandez", Address = "707 Saga Pl, Prosetown, USA 89012", Email = "lisa.hernandez@email.com", IsActive = true},
            new Patron {Id = 10, FirstName = "Mark", LastName = "Lopez", Address = "808 Narrative Rd, Storyburgh, USA 90123", Email = "mark.lopez@email.com", IsActive = true},
            new Patron {Id = 11, FirstName = "Sophia", LastName = "Lee", Address = "909 Fable Blvd, Plotville, USA 01234", Email = "sophia.lee@email.com", IsActive = false},
            new Patron {Id = 12, FirstName = "Kevin", LastName = "Clark", Address = "1010 Myth St, Genretown, USA 12345", Email = "kevin.clark@email.com", IsActive = true}
        });

        modelBuilder.Entity<Material>().HasData(new Material[]
        {
            // Checked In Items (11 items)
            new Material {Id = 1, MaterialName = "The Magic Mountain", MaterialTypeId = 1, GenreId = 6, OutOfCirculationSince = null},
            new Material {Id = 2, MaterialName = "Interstellar Soundtrack", MaterialTypeId = 2, GenreId = 2, OutOfCirculationSince = null},
            new Material {Id = 3, MaterialName = "Nature's Wonders", MaterialTypeId = 3, GenreId = 3, OutOfCirculationSince = null},
            new Material {Id = 4, MaterialName = "Inception", MaterialTypeId = 4, GenreId = 2, OutOfCirculationSince = null},
            new Material {Id = 5, MaterialName = "The Odyssey Audiobook", MaterialTypeId = 5, GenreId = 6, OutOfCirculationSince = null},
            new Material {Id = 6, MaterialName = "The Enchanted Forest", MaterialTypeId = 1, GenreId = 1, OutOfCirculationSince = null},
            new Material {Id = 7, MaterialName = "Science Today", MaterialTypeId = 3, GenreId = 2, OutOfCirculationSince = null},
            new Material {Id = 8, MaterialName = "Classical Melodies", MaterialTypeId = 2, GenreId = 4, OutOfCirculationSince = null},
            new Material {Id = 9, MaterialName = "Jurassic Park", MaterialTypeId = 4, GenreId = 2, OutOfCirculationSince = null},
            new Material {Id = 10, MaterialName = "To Kill a Mockingbird Audiobook", MaterialTypeId = 5, GenreId = 6, OutOfCirculationSince = null},
            new Material {Id = 11, MaterialName = "Galaxy Exploration", MaterialTypeId = 1, GenreId = 2, OutOfCirculationSince = null},

            // Checked Out Items (16 items, not overdue)
            new Material {Id = 12, MaterialName = "The Invisible Man", MaterialTypeId = 1, GenreId = 3, OutOfCirculationSince = new DateTime(2023, 12, 08)},
            new Material {Id = 13, MaterialName = "Beethoven's Symphony", MaterialTypeId = 2, GenreId = 4, OutOfCirculationSince = new DateTime(2023, 12, 10)},
            new Material {Id = 14, MaterialName = "Modern Art Today", MaterialTypeId = 3, GenreId = 7, OutOfCirculationSince = new DateTime(2023, 12, 13)},
            new Material {Id = 15, MaterialName = "The Matrix", MaterialTypeId = 4, GenreId = 2, OutOfCirculationSince = new DateTime(2023, 12, 12)},
            new Material {Id = 16, MaterialName = "Pride and Prejudice Audiobook", MaterialTypeId = 5, GenreId = 4, OutOfCirculationSince = new DateTime(2023, 12, 08)},
            new Material {Id = 17, MaterialName = "Dragon's Realm", MaterialTypeId = 1, GenreId = 1, OutOfCirculationSince = new DateTime(2023, 12, 08)},
            new Material {Id = 18, MaterialName = "Guitar Classics", MaterialTypeId = 2, GenreId = 4, OutOfCirculationSince = new DateTime(2023, 12, 10)},
            new Material {Id = 19, MaterialName = "Tech Innovations", MaterialTypeId = 3, GenreId = 2, OutOfCirculationSince = new DateTime(2023, 12, 13)},
            new Material {Id = 20, MaterialName = "Shawshank Redemption", MaterialTypeId = 4, GenreId = 5, OutOfCirculationSince = new DateTime(2023, 12, 12)},
            new Material {Id = 21, MaterialName = "The Great Gatsby Audiobook", MaterialTypeId = 5, GenreId = 6, OutOfCirculationSince = new DateTime(2023, 12, 08)},
            new Material {Id = 22, MaterialName = "Futuristic Visions", MaterialTypeId = 1, GenreId = 2, OutOfCirculationSince = new DateTime(2023, 12, 08)},

            // Checked Out Items (3 items, overdue)
            new Material {Id = 23, MaterialName = "Murder on the Orient Express", MaterialTypeId = 1, GenreId = 3, OutOfCirculationSince = new DateTime(2023, 12, 01)}, // Overdue (Book)
            new Material {Id = 24, MaterialName = "Jazz Nights", MaterialTypeId = 2, GenreId = 4, OutOfCirculationSince = new DateTime(2023, 12, 05)}, // Overdue (CD)
            new Material {Id = 25, MaterialName = "Historical Review", MaterialTypeId = 3, GenreId = 7, OutOfCirculationSince = new DateTime(2023, 12, 11)}, // Overdue (Periodical)

            // Continuing with Checked Out Items (not overdue)
            new Material {Id = 26, MaterialName = "Star Wars", MaterialTypeId = 4, GenreId = 2, OutOfCirculationSince = new DateTime(2023, 12, 12)},
            new Material {Id = 27, MaterialName = "1984 Audiobook", MaterialTypeId = 5, GenreId = 2, OutOfCirculationSince = new DateTime(2023, 12, 08)},
            new Material {Id = 28, MaterialName = "Alice in Wonderland", MaterialTypeId = 1, GenreId = 1, OutOfCirculationSince = new DateTime(2023, 12, 08)},
            new Material {Id = 29, MaterialName = "Opera Classics", MaterialTypeId = 2, GenreId = 4, OutOfCirculationSince = new DateTime(2023, 12, 10)},
            new Material {Id = 30, MaterialName = "World News Weekly", MaterialTypeId = 3, GenreId = 7, OutOfCirculationSince = new DateTime(2023, 12, 13)},
            new Material {Id = 31, MaterialName = "Harry Potter Series", MaterialTypeId = 1, GenreId = 1, OutOfCirculationSince = new DateTime(2023, 12, 08)}
        });

        modelBuilder.Entity<Checkout>().HasData(new Checkout[]
        {
            // Current Checkouts (19 items)
            new Checkout {Id = 1, MaterialId = 12, PatronId = 1, CheckoutDate = new DateTime(2023, 12, 08), ReturnDate = null},
            new Checkout {Id = 2, MaterialId = 13, PatronId = 2, CheckoutDate = new DateTime(2023, 12, 10), ReturnDate = null},
            new Checkout {Id = 3, MaterialId = 14, PatronId = 3, CheckoutDate = new DateTime(2023, 12, 13), ReturnDate = null},
            new Checkout {Id = 4, MaterialId = 15, PatronId = 4, CheckoutDate = new DateTime(2023, 12, 12), ReturnDate = null},
            new Checkout {Id = 5, MaterialId = 16, PatronId = 5, CheckoutDate = new DateTime(2023, 12, 08), ReturnDate = null},
            new Checkout {Id = 6, MaterialId = 17, PatronId = 6, CheckoutDate = new DateTime(2023, 12, 08), ReturnDate = null},
            new Checkout {Id = 7, MaterialId = 18, PatronId = 7, CheckoutDate = new DateTime(2023, 12, 10), ReturnDate = null},
            new Checkout {Id = 8, MaterialId = 19, PatronId = 8, CheckoutDate = new DateTime(2023, 12, 13), ReturnDate = null},
            new Checkout {Id = 9, MaterialId = 20, PatronId = 9, CheckoutDate = new DateTime(2023, 12, 12), ReturnDate = null},
            new Checkout {Id = 10, MaterialId = 21, PatronId = 10, CheckoutDate = new DateTime(2023, 12, 08), ReturnDate = null},
            new Checkout {Id = 11, MaterialId = 22, PatronId = 11, CheckoutDate = new DateTime(2023, 12, 08), ReturnDate = null},
            new Checkout {Id = 12, MaterialId = 23, PatronId = 12, CheckoutDate = new DateTime(2023, 12, 01), ReturnDate = null}, // Overdue
            new Checkout {Id = 13, MaterialId = 24, PatronId = 1, CheckoutDate = new DateTime(2023, 12, 05), ReturnDate = null}, // Overdue
            new Checkout {Id = 14, MaterialId = 25, PatronId = 2, CheckoutDate = new DateTime(2023, 12, 11), ReturnDate = null}, // Overdue
            new Checkout {Id = 15, MaterialId = 26, PatronId = 3, CheckoutDate = new DateTime(2023, 12, 12), ReturnDate = null},
            new Checkout {Id = 16, MaterialId = 27, PatronId = 4, CheckoutDate = new DateTime(2023, 12, 08), ReturnDate = null},
            new Checkout {Id = 17, MaterialId = 28, PatronId = 5, CheckoutDate = new DateTime(2023, 12, 08), ReturnDate = null},
            new Checkout {Id = 18, MaterialId = 29, PatronId = 6, CheckoutDate = new DateTime(2023, 12, 10), ReturnDate = null},
            new Checkout {Id = 19, MaterialId = 30, PatronId = 7, CheckoutDate = new DateTime(2023, 12, 13), ReturnDate = null},

            // Past Checkouts (some overdue)
            // The pattern will continue with MaterialId and PatronId, and dates will be in the past
            new Checkout {Id = 20, MaterialId = 31, PatronId = 8, CheckoutDate = new DateTime(2023, 11, 15), ReturnDate = new DateTime(2023, 11, 22)},
            new Checkout {Id = 21, MaterialId = 1, PatronId = 9, CheckoutDate = new DateTime(2023, 10, 10), ReturnDate = new DateTime(2023, 10, 17)}, // Overdue Return
            new Checkout {Id = 22, MaterialId = 2, PatronId = 10, CheckoutDate = new DateTime(2023, 09, 05), ReturnDate = new DateTime(2023, 09, 12)},
            new Checkout {Id = 23, MaterialId = 3, PatronId = 11, CheckoutDate = new DateTime(2023, 08, 20), ReturnDate = new DateTime(2023, 08, 27)},
            new Checkout {Id = 24, MaterialId = 4, PatronId = 12, CheckoutDate = new DateTime(2023, 07, 15), ReturnDate = new DateTime(2023, 07, 22)},
            new Checkout {Id = 25, MaterialId = 5, PatronId = 1, CheckoutDate = new DateTime(2023, 06, 10), ReturnDate = new DateTime(2023, 06, 17)},
            new Checkout {Id = 26, MaterialId = 6, PatronId = 2, CheckoutDate = new DateTime(2023, 05, 05), ReturnDate = new DateTime(2023, 05, 12)},
            new Checkout {Id = 27, MaterialId = 7, PatronId = 3, CheckoutDate = new DateTime(2023, 04, 20), ReturnDate = new DateTime(2023, 04, 27)},
            new Checkout {Id = 28, MaterialId = 8, PatronId = 4, CheckoutDate = new DateTime(2023, 03, 15), ReturnDate = new DateTime(2023, 03, 22)},
            new Checkout {Id = 29, MaterialId = 9, PatronId = 5, CheckoutDate = new DateTime(2023, 02, 10), ReturnDate = new DateTime(2023, 02, 17)}, // Overdue Return
            new Checkout {Id = 30, MaterialId = 10, PatronId = 6, CheckoutDate = new DateTime(2023, 01, 05), ReturnDate = new DateTime(2023, 01, 12)},
            new Checkout {Id = 31, MaterialId = 11, PatronId = 7, CheckoutDate = new DateTime(2022, 12, 20), ReturnDate = new DateTime(2022, 12, 27)},
            new Checkout {Id = 32, MaterialId = 12, PatronId = 8, CheckoutDate = new DateTime(2022, 11, 15), ReturnDate = new DateTime(2022, 11, 22)},
            new Checkout {Id = 33, MaterialId = 13, PatronId = 9, CheckoutDate = new DateTime(2022, 10, 10), ReturnDate = new DateTime(2022, 10, 17)},
            new Checkout {Id = 34, MaterialId = 14, PatronId = 10, CheckoutDate = new DateTime(2022, 09, 05), ReturnDate = new DateTime(2022, 09, 12)},
            new Checkout {Id = 35, MaterialId = 15, PatronId = 11, CheckoutDate = new DateTime(2022, 08, 20), ReturnDate = new DateTime(2022, 08, 27)}, // Overdue Return
            new Checkout {Id = 36, MaterialId = 16, PatronId = 12, CheckoutDate = new DateTime(2022, 07, 15), ReturnDate = new DateTime(2022, 07, 22)},
            new Checkout {Id = 37, MaterialId = 17, PatronId = 1, CheckoutDate = new DateTime(2022, 06, 10), ReturnDate = new DateTime(2022, 06, 17)},
            new Checkout {Id = 38, MaterialId = 18, PatronId = 2, CheckoutDate = new DateTime(2022, 05, 05), ReturnDate = new DateTime(2022, 05, 12)},
            new Checkout {Id = 39, MaterialId = 19, PatronId = 3, CheckoutDate = new DateTime(2022, 04, 20), ReturnDate = new DateTime(2022, 04, 27)},
            new Checkout {Id = 40, MaterialId = 20, PatronId = 4, CheckoutDate = new DateTime(2022, 03, 15), ReturnDate = new DateTime(2022, 03, 22)},
            new Checkout {Id = 41, MaterialId = 21, PatronId = 5, CheckoutDate = new DateTime(2022, 02, 10), ReturnDate = new DateTime(2022, 02, 17)},
        });
    }
}